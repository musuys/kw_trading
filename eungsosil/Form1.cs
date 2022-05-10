using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;

namespace eungsosil

{
    public partial class Form1 : Form
    {
        string g_user_id = null;
        string g_accnt_no = null;
        string g_user_name = null;
        List<PriceInfo> priceList;

        int g_is_thread = 0;
        Thread thread1 = null;

        public Form1()
        {
            InitializeComponent();
            
        }

        public string get_cur_tm()
        {
            DateTime l_cur_time;
            string l_cur_tm;

            l_cur_time = DateTime.Now; //현재시각을 1_cur_time에 저장
            l_cur_tm = l_cur_time.ToString("HHmmss"); // 시분초를 1_cur_tm에 저장

            return l_cur_tm; //현재시각 리턴
            
        }

        public string get_jongmok_nm(string i_jongmok_cd) //종목코드를 입력값으로 받음
        {
            string l_jongmok_nm = null;

            l_jongmok_nm = axKHOpenAPI1.GetMasterCodeName(i_jongmok_cd);
            return l_jongmok_nm;
        }


        //DB

        private OracleConnection connect_db() //오라클 연결 변수 리턴
        {
            String conninfo = "User Id=ats;" +
                "Passwor1234;" +
                "Data Source=(DESCRIPTION=" +
                "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)) );"; //접속정보 변수저장

            OracleConnection conn = new OracleConnection(conninfo);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("connect_db() FAIL! " + ex.Message, "오류 발생");
                conn = null;
            }
            return conn;
        }



        //메시지로그출력 메서드 구현X
        //지연 메서드 구현X


        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public DateTime delay(int MS) //딜레이 매서드
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                try
                {
                    unsafe
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                catch (AccessViolationException ex)
                {
                    //write_err_log("delay() ex.Message : [" + ex.Message + "]\n", 0);
                }

                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }


        //요청번호 부여 메서드
        int g_scr_no = 0; //open Api 요청번호

        private string get_scr_no()
        {
            if (g_scr_no < 9999)
                g_scr_no++;
            else
                g_scr_no = 1000;

            return g_scr_no.ToString();
        }

        //로그인
        private void mnuLogin_Click(object sender, EventArgs e)
        {
            int ret = 0;
            int ret2 = 0;

            
            String l_accno = null;//증권계좌번호
            String l_accno_cnt = null;//소유한 증권계좌번호수
            String[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

            ret = axKHOpenAPI1.CommConnect(); //로그인 창 호출

            if (ret == 0)
            {
                toolStripStatusLabel1.Text = "로그인 중...";

                for (; ; )
                {
                    ret2 = axKHOpenAPI1.GetConnectState(); //로그인 완료 여부를 가져옴
                    if (ret2 == 1)
                    {
                        break;
                    }
                    else
                    {
                        delay(1000); 
                    }
                }

                toolStripStatusLabel1.Text = "로그인 완료";
                tmp_info();
                g_user_id = "";
                g_user_id = axKHOpenAPI1.GetLoginInfo("USER_ID").Trim();

                g_user_name = "";
                g_user_name = axKHOpenAPI1.GetLoginInfo("USER_NAME").Trim();

                txtID.Text = g_user_id;
                txtName.Text = g_user_name;

                l_accno_cnt = "";
                l_accno_cnt = axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT").Trim();

                l_accno_arr = new String[int.Parse(l_accno_cnt)];
                l_accno = "";
                l_accno = axKHOpenAPI1.GetLoginInfo("ACCNO").Trim();

                l_accno_arr = l_accno.Split(';');

                cmbAcnum1.Items.Clear();
                cmbAcnum1.Items.AddRange(l_accno_arr);
                cmbAcnum1.SelectedIndex = 0;
                g_accnt_no = cmbAcnum1.SelectedItem.ToString().Trim();
            }
        }

        //로그아웃
        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
            toolStripStatusLabel1.Text = "로그아웃 완료";
            txtID.Text = null;
            txtName.Text = null;
            stockList.Items.Clear();
            txtSearch.Text = null;
        }

        //증권계좌번호
        private void cmbAcnum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //g_accnt_no = ComboBox1.SelectedItem.ToString().Trim();
            //write_msg_log("사용할 증권계좌번호는 ; [" + g_accnt_no + "] 입니다. \n", 0);
        }


        

        //거래종목 조회
        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd;
            OracleConnection conn;
            OracleDataReader reader = null;

            string sql;

            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;
            int l_seq = 0;
            string[] l_arr = null;

            conn = null;
            conn = connect_db();

            cmd = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = null;
            sql = " SELECT     " +
                  "   JONGMOK_CD  ,    " +
                  "   JONGMOK_NM  ,    " +
                  "   PRIORITY  ,    " +
                  "   BUY_AMT  ,    " +
                  "   BUY_PRICE  ,    " +
                  "   TARGET_PRICE  ,    " +
                  "   CUT_LOSS_PRICE  ,    " +
                  "   BUY_TRD_YN  ,    " +
                  "   SELL_TRD_YN      " +
                  " FROM    " +
                  "   TB_TRD_JONGMOK    " +
                  "   WHERE USER_ID = " + "'" + g_user_id + "' order by PRIORITY  ";

            cmd.CommandText = sql;

            this.Invoke(new MethodInvoker(
                delegate ()
                {
                    dataGridView1.Rows.Clear(); //그리드뷰 초기화
                }));

            try
            {
                reader = cmd.ExecuteReader(); // SQL수행
            }

            catch (Exception ex)
            {
                //write_err_log("SELECT TB_TRD_JONGMOK ex.Message : [" + ex.Message + "]\n", 0);
            }

            l_jongmok_cd = "";
            l_jongmok_nm = "";
            l_priority=0;
            l_buy_amt=0;
            l_buy_price = 0;
            l_target_price=0;
            l_cut_loss_price=0;
            l_buy_trd_yn="";
            l_sell_trd_yn="";
            
            while (reader.Read())
            {
                l_seq++;
                l_jongmok_cd = "";
                l_jongmok_nm = "";
                l_priority = 0;
                l_buy_amt = 0;
                l_buy_price = 0;
                l_target_price = 0;
                l_cut_loss_price = 0;
                l_buy_trd_yn = "";
                l_sell_trd_yn = "";
                l_seq = 0;

                l_jongmok_cd = reader[0].ToString().Trim();
                l_jongmok_nm = reader[1].ToString().Trim();
                l_priority = int.Parse(reader[2].ToString().Trim());
                l_buy_amt = int.Parse(reader[3].ToString().Trim());
                l_buy_price = int.Parse(reader[4].ToString().Trim());
                l_target_price = int.Parse(reader[5].ToString().Trim());
                l_cut_loss_price = int.Parse(reader[6].ToString().Trim());
                l_buy_trd_yn = reader[7].ToString().Trim();
                l_sell_trd_yn = reader[8].ToString().Trim();

                l_arr = null;
                l_arr = new string[]
                {
                    l_seq.ToString(),
                    l_jongmok_cd,
                    l_jongmok_nm,
                    l_priority.ToString(),
                    l_buy_amt.ToString(),
                    l_buy_price.ToString(),
                    l_target_price.ToString(),
                    l_cut_loss_price.ToString(),
                    l_buy_trd_yn,
                    l_sell_trd_yn
                };
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        dataGridView1.Rows.Add(l_arr) ; //데이터그리드뷰에 추가
                    }));
            }
        }

        //거래종목 삽입
        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd;
            OracleConnection conn;

            string sql;

            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;

            foreach(DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }
                if(Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();
                    l_jongmok_nm = Row.Cells[2].Value.ToString();
                    l_priority = int.Parse(Row.Cells[3].Value.ToString());
                    l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
                    l_buy_price = int.Parse(Row.Cells[5].Value.ToString());

                    l_target_price = int.Parse(Row.Cells[6].Value.ToString());
                    l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());

                    l_buy_trd_yn = Row.Cells[8].Value.ToString();
                    l_sell_trd_yn = Row.Cells[9].Value.ToString();

                    conn = null;
                    conn = connect_db();

                    cmd = null;
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    sql = null;
                    sql = @"insert into TB_TRD_JONGMOK values " +
                                "(" +
                                    "'" + g_user_id + "'" + "," +
                                    "'" + l_jongmok_cd + "'" + "," +
                                    "'" + l_jongmok_nm + "'" + "," +
                                        +l_priority + "," +
                                        +l_buy_amt + "," +
                                        +l_buy_price + "," +
                                        +l_target_price + "," +
                                        +l_cut_loss_price + "," +
                                    "'" + l_buy_trd_yn + "'" + "," +
                                    "'" + l_sell_trd_yn + "'" + "," +
                                    "'" + g_user_id + "'" + "," +
                                    "sysdate " + "," +
                                    "NULL" + "," +
                                    "NULL" +
                                ")";
                    cmd.CommandText = sql;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        //에러로그 출력
                    }
                    //메세지로그 출력 코드 
                    conn.Close();


                }
            }

        }

        //종목 수정버튼
        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd;
            OracleConnection conn;

            string sql;

            string l_jongmok_cd;
            string l_jongmok_nm;
            int l_priority;
            int l_buy_amt;
            int l_buy_price;
            int l_target_price;
            int l_cut_loss_price;
            string l_buy_trd_yn;
            string l_sell_trd_yn;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();
                    l_jongmok_nm = Row.Cells[2].Value.ToString();
                    l_priority = int.Parse(Row.Cells[3].Value.ToString());
                    l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
                    l_buy_price = int.Parse(Row.Cells[5].Value.ToString());

                    l_target_price = int.Parse(Row.Cells[6].Value.ToString());
                    l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());

                    l_buy_trd_yn = Row.Cells[8].Value.ToString();
                    l_sell_trd_yn = Row.Cells[9].Value.ToString();

                    conn = null;
                    conn = connect_db();

                    cmd = null;
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    sql = null;

                    sql = @" UPDATE TB_TRD_JONGMOK
                            SET
                                JONGMOK_NM = " + "'" + l_jongmok_nm + "'" + "," +
                                " PRIORITY = " + l_priority + "," +
                                " BUY_AMT = " + l_buy_amt + "," +
                                " BUY_PRICE = " + l_buy_price + "," +
                                " TARGET_PRICE = " + l_target_price + "," +
                                " CUT_LOSS_PRICE = " + l_cut_loss_price + "," +
                                " BUY_TRD_YN = " + l_buy_trd_yn + "," +
                                " SELL_TRD_YN = " + l_sell_trd_yn + "," +
                                " UPDT_ID = " + g_user_id + "," +
                                " UPDT_DTM = SYSDATE " +
                            "WHERE JONGMMOK_CD = " + "'" + l_jongmok_cd + "'" +
                            "AND USER_ID = " + "'" + g_user_id + "'";

                    cmd.CommandText = sql;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //에러로그 출력
                    }
                    //메세지로그 출력 코드 
                    conn.Close();
                }
            }
        }

        //종목 삭제버튼
        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd;
            OracleConnection conn;

            string sql;

            string l_jongmok_cd = null;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells[1].Value.ToString();

                    conn = null;
                    conn = connect_db();

                    cmd = null;
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    sql = null;

                    sql = @" DELETE FROM TB_TRD_JONGMOK " +
                           " WHERE JONGMOK_CD = " + "'" + l_jongmok_cd + "'" +
                           " AND USER_ID = " + "'" + g_user_id + "'";

                    cmd.CommandText = sql;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //에러로그 출력
                    }
                    //메세지로그 출력 코드 
                    conn.Close();
                }
            }
        }


        /* 차트 */

        class PriceInfo
        {
            public string date { get; set; }
            public int initial_price { get; set; }
            public int high_price { get; set; }
            public int low_price { get; set; }
            public int end_price { get; set; }
        }

        private void tmp_info()
        {
            string l = axKHOpenAPI1.GetCodeListByMarket("0");
            string[] lst = l.Split(';');
            for (int i = 0; i < lst.Length; i++)
                stockList.Items.Add(lst[i]);
        }

        // 차트를 그리기 위한 데이터 요청
        private void requestChart()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            axKHOpenAPI1.SetInputValue("기준일자", date);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");

            if (nRet != 0)
                MessageBox.Show("차트요청 실패");
        }

        // 주식 정보요청
        private void requestInfo()
        {
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            int iRet = axKHOpenAPI1.CommRqData("종목정보요청", "OPT10001", 0, "1003");

            if (iRet != 0)
                MessageBox.Show("정보요청 실패");

        }
        private void axKHOpenAPI1_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            // 현재가
            string cur_price = axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim();
            int c = Int32.Parse(cur_price);
            cur_price = String.Format("{0:C}", Math.Abs(c));


            // 누적 거래량
            string amount = axKHOpenAPI1.GetCommRealData(e.sRealType, 13).Trim();
            amount = String.Format("{0:n0}", Int32.Parse(amount));

            // 등락율
            string rate = axKHOpenAPI1.GetCommRealData(e.sRealType, 12).Trim();
            double r = Double.Parse(rate);

            // 전일 대비
            string diff = axKHOpenAPI1.GetCommRealData(e.sRealType, 11).Trim();
            int d = Int32.Parse(diff);
            diff = String.Format("{0:C}", Math.Abs(d));


            // 상한가
            string max = high_price_label.Text;
            max = max.Substring(1);
            max = max.Replace(",", "");

            if (c > Int32.Parse(max))
            {
                max = Convert.ToString(c);
                high_price_label.Text = String.Format("{0:C}", max);
            }

            // 하한가
            string min = low_price_label.Text;
            min = min.Substring(1);
            min = min.Replace(",", "");

            if (Math.Abs(c) < Int32.Parse(min))
            {
                min = Convert.ToString(Math.Abs(c));
                low_price_label.Text = String.Format("{0:C}", min);
            }

            // 52주 최고
            string year_max = year_high.Text;
            year_max = year_max.Substring(1);
            year_max = year_max.Replace(",", "");

            if (c > Int32.Parse(year_max))
            {
                year_max = Convert.ToString(c);
                year_high.Text = String.Format("{0:C}", year_max);
            }

            //52주 최저
            string year_min = year_low.Text;
            year_min = year_min.Substring(1);
            year_min = year_min.Replace(",", "");

            if (Math.Abs(c) < Int32.Parse(year_min))
            {
                year_min = Convert.ToString(Math.Abs(c));
                year_low.Text = String.Format("{0:C}", year_min);
            }

            // + / - 에 대하여 텍스트 색상 변경
            if (r == 0.00)
            {
                current_price.ForeColor = Color.Gray;
                difference.ForeColor = Color.Gray;
            }
            else if (r > 0)
            {
                current_price.ForeColor = Color.Red;
                difference.ForeColor = Color.Red;
            }
            else if (r < 0)
            {
                current_price.ForeColor = Color.Blue;
                difference.ForeColor = Color.Blue;
            }
            current_price.Text = cur_price;
            difference.Text = diff + " | " + rate + "%";
            total_amount.Text = amount;

            // 실시간 현재 가격 get
            int cur_init_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim()));

            // 캔들 차트에 실시간 데이터를 반영
            if (is_Same_CandleData(priceList[0].date))
            {
                // 가격의 변동이 있는 경우 반영
                priceList[0].end_price = cur_init_price;
                if (priceList[0].high_price < cur_init_price)
                    priceList[0].high_price = cur_init_price;
                if (priceList[0].low_price > cur_init_price)
                    priceList[0].low_price = cur_init_price;

                // 현재 가격과 차트에 표현된 가격을 비교하여 업데이트
                // 현재가가 고가보다 높아지는 경우 고가 캔들 상단 업데이트
                if (cur_init_price > stockChart.Series["chart_data"].Points[0].YValues[0])
                    stockChart.Series["chart_data"].Points[0].YValues[0] = cur_init_price;

                // 현재가가 저가보다 낮아지는 경우 저가 캔들 하단 업데이트
                if (stockChart.Series["chart_data"].Points[0].YValues[1] > cur_init_price)
                    stockChart.Series["chart_data"].Points[0].YValues[1] = cur_init_price;
                stockChart.Series["chart_data"].Points[0].YValues[3] = cur_init_price;

                // 결과를 차트에 새롭게 반영
                stockChart.Invalidate();
            }
            else
            {
                double next_time = double.Parse(priceList[0].date) + 100;
                PriceInfo item = new PriceInfo();
                item.date = next_time.ToString();

                item.end_price = item.high_price = item.low_price = item.initial_price = cur_init_price;
                // 신규 캔들의 경우 list 맨 처음에 추가하여 가장 우측에 출력되도록 설정
                priceList.Insert(0, item);

                stockChart.Series["chart_data"].Points.InsertXY(0, item.date, item.high_price);
                stockChart.Series["chart_data"].Points[0].YValues[1] = item.low_price;
                stockChart.Series["chart_data"].Points[0].YValues[2] = item.initial_price;
                stockChart.Series["chart_data"].Points[0].YValues[3] = item.end_price;
                stockChart.Invalidate();
            }
        }

        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            // 한번 data 받아서 data 출력
            if (e.sRQName == "종목정보요청")
            {
                
                string code= axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();

                string name = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
                string cur_price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
                int c = Int32.Parse(cur_price);
                cur_price = String.Format("{0:C}", Math.Abs(c));

                string init_price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim();
                int init = Int32.Parse(init_price);
                init_price = String.Format("{0:C}", Math.Abs(init));

                string rate = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();
                string diff = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "전일대비").Trim();
                int d = Int32.Parse(diff);
                diff = string.Format("{0:C}", Math.Abs(d));

                string high = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "상한가").Trim();
                high = string.Format("{0:C}", Int32.Parse(high));

                string low = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "하한가").Trim();
                low = string.Format("{0:C}", Int32.Parse(low) * (-1));

                string amount = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim();
                amount = String.Format("{0:n0}", Int32.Parse(amount));

                string highest = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "250최고").Trim();
                highest = string.Format("{0:C}", Int32.Parse(highest));

                string lowest = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "250최저").Trim();
                lowest = string.Format("{0:C}", Int32.Parse(lowest) * (-1));

                // 종목코드 추가 출력
                stock_name.Text = name + ' ' + '(' + code + ')';
                if (d == 0)
                    current_price.ForeColor = Color.Gray;
                else if (c > 0)
                    current_price.ForeColor = Color.Red;
                else if (c < 0)
                    current_price.ForeColor = Color.Blue;
                current_price.Text = cur_price;

                if (Double.Parse(rate) < 0)
                    difference.ForeColor = Color.Blue;
                else if (Double.Parse(rate) > 0)
                    difference.ForeColor = Color.Red;
                else
                    difference.ForeColor = Color.Gray;
                difference.Text = diff + " | " + rate + "%";

                start_price.Text = init_price;
                high_price.Text = high;
                low_price.Text = low;
                total_amount.Text = amount;
                year_high.Text = highest;
                year_low.Text = lowest;
            }

            // 차트 1번만 출력, 갱신  X
            else if (e.sRQName == "주식일봉차트조회")
            {
                int count = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                for (int i = 0; i < count; i++)
                {
                    priceList.Add(new PriceInfo()
                    {
                        date = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "일자").Trim(),
                        initial_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가").Trim())),
                        high_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가").Trim())),
                        low_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가").Trim())),
                        end_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim())),
                    });
                    stockChart.Series["chart_data"].Points.AddXY(priceList[i].date, priceList[i].high_price);
                    stockChart.Series["chart_data"].Points[i].YValues[1] = priceList[i].low_price;
                    stockChart.Series["chart_data"].Points[i].YValues[2] = priceList[i].initial_price;
                    stockChart.Series["chart_data"].Points[i].YValues[3] = priceList[i].end_price;
                }

                // AxisViewChanged이후 zoom을 Reset해서 차트 X, Y 비율 조정
                int max = priceList.Max(m => m.high_price);
                int min = priceList.Min(n => n.low_price);
                stockChart.ChartAreas[0].AxisY.Maximum = max;
                stockChart.ChartAreas[0].AxisY.Minimum = min;
                stockChart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            }
        }

        // 실시간 차트 업데이트를 위해 같은 같은 캔들 차트 사용 판단
        bool is_Same_CandleData(string date)
        {
            string now_time = DateTime.Now.ToString("yyyyMMdd");
            return date == now_time;
        }

        private void stockChart_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
            int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

            int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
            int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;

            for (int i = startPosition - 1; i < endPosition; i++)
            {
                if (i >= priceList.Count)
                    break;
                if (i < 0)
                    i = 0;
                if (priceList[i].high_price > max)
                    max = priceList[i].high_price;
                if (priceList[i].low_price < min)
                    min = priceList[i].low_price;
            }
            stockChart.ChartAreas[0].AxisY.Maximum = max;
            stockChart.ChartAreas[0].AxisY.Minimum = min;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            stockChart.Series["chart_data"].Points.Clear();
            priceList = new List<PriceInfo>();
            requestInfo();
            requestChart();
            string d = DateTime.Now.ToString("yyyyMMdd");
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            axKHOpenAPI1.SetInputValue("기준일자", d);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            if (nRet != 0)
                MessageBox.Show("차트조회 실패");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }




        //자동매매


        public void m_thread1()
        {
            string l_cur_tm = null;

            if(g_is_thread == 0)
            {
                g_is_thread = 1;
                MessageBox.Show("자동매매가 시작되었습니다. \n");
            }
            for(; ; )
            {
                l_cur_tm = get_cur_tm();
                if(l_cur_tm.CompareTo("083001")>=0)
                {
                    //계좌 조회, 계좌정보 조호ㅚ, 보유종목 매도수문 수행
                }
                if(l_cur_tm.CompareTo("090001")>=0)
                {
                    for(; ; )
                    {
                        l_cur_tm = get_cur_tm();//현재시각 조회
                        if(l_cur_tm.CompareTo("153001")>=0)
                        {
                            break;
                        }
                        delay(200);
                    }
                }
                delay(200);
            }
        }
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }
            if (g_is_thread == 1)
            {

                MessageBox.Show("자동 매매가 이미 시작되었습니다.\n");
                return;
            }
            g_is_thread = 1;
            thread1 = new Thread(new ThreadStart(m_thread1));
            thread1.Start();

        }

        private void btnAutoEnd_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }
            MessageBox.Show("자동 매매 종료 시도\n");
            try
            {
                thread1.Abort();
            }catch (Exception ex)
            {
                MessageBox.Show("자동매매 중지 (" + ex.Message + ")\n");
            }
            this.Invoke(new MethodInvoker(() => 
                {
                if(thread1 != null)
                {
                    thread1.Interrupt();
                    thread1 = null;
                }
            }));
            g_is_thread = 0;

            MessageBox.Show("자동매매 중지 완료\n");


        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if(axKHOpenAPI1.GetConnectState()!=1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }
            accountForm af = new accountForm();
            DialogResult dResult = af.ShowDialog();
          

        }




        //종목명으로 종목정보,차트검색하기
        public void stockSearch(object sender, EventArgs e)
        {

            stockChart.Series["chart_data"].Points.Clear();
            priceList = new List<PriceInfo>();


            string 종목코드리스트 = axKHOpenAPI1.GetCodeListByMarket("0");
            string[] 종목코드 = 종목코드리스트.Split(';');

            string 종목명 = txtSearch.Text;
            for (int i = 0; i < 종목코드.Length; i++)
            {
                if (txtSearch.Text.Length > 0 && txtSearch.Text == axKHOpenAPI1.GetMasterCodeName(종목코드[i]))
                {

                    //종목정보요청
                    axKHOpenAPI1.SetInputValue("종목코드", 종목코드[i]);
                    int iRet = axKHOpenAPI1.CommRqData("종목정보요청", "OPT10001", 0, "1002");

                    if (iRet != 0)
                        MessageBox.Show("정보요청 실패");


                    //차트 요청
                    string date = DateTime.Now.ToString("yyyyMMdd");
                    axKHOpenAPI1.SetInputValue("종목코드", 종목코드[i]);
                    axKHOpenAPI1.SetInputValue("기준일자", date);
                    axKHOpenAPI1.SetInputValue("수정주가구분", "1");

                    int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");

                    if (nRet != 0)
                        MessageBox.Show("차트요청 실패");


                    /*axKHOpenAPI1.SetInputValue("종목코드", 종목코드[i]);
                    axKHOpenAPI1.CommRqData("종목정보요청", "opt10001", 0, "5000");*/
                }

               
            }

        }


        private void cmbAcnum1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        /*

public void write_msg_log(String text, int is_clear)
{
DateTime l_cur_time;
String l_cur_dt;
String l_cur_tm;
String l_cur_dtm;

l_cur_dt = "";
l_cur_tm = "";

l_cur_time = DateTime.Now;
l_cur_dt = l_cur_time.ToString("yyyy-") + l_cur_time.ToString("MM-") + l_cur_time.ToString("dd");

l_cur_tm = l_cur_time.ToString("HH:mm:ss");
l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";

if(is_clear ==  1)
{
MessageBox.Show("test");
}
else
{
if(this.textbox)
}


}*/
    }
}
