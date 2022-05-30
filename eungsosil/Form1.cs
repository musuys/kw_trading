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
        Dictionary<string, string> dict = new Dictionary<string, string>(); // 코드명, 주식이름 저장 dict
        Dictionary<String, int> stock_dict = new Dictionary<string, int>(); // 주식명, 수량 저장 dict

        /* 자동매매 변수 추가 */
        int acAll;
        int ac;
        int all;
        int allBen;

        string l_accno_cnt;
        string l_acc_no;
        string[] l_accno_arr;

        int g_ord_amt_possible = 0;
        int g_flag_1 = 0;
        int g_flag_2 = 0;//1이면 요청에 대한 응답 완료
        int g_flag_6 = 0;//현재가 조회 플래그 변수가 1이면 조회 완료
        int g_flag_3 = 0;//매수주문 응답 플래그
        int g_flag_4 = 0;//매도주문 응답 플래그
        int g_flag_5 = 0; //매도취소주문 응답 플래그

        int g_cur_price = 0;//현재가
        int g_buy_hoga = 0;//최우선 매수호가 저장 변수
        int g_flag_7 = 0;//최우선 매수호가 플래그 변수가 1이면 조회 완료

        int g_is_next = 0;
        string g_rqname = null;

        int g_is_thread = 0;
        Thread thread1 = null;

        public Form1()
        {
            InitializeComponent();

        }
        
        //DB
        private OracleConnection connect_db() //오라클 연결 변수 리턴
        {
            //   String conninfo = "User Id=ats;" +
            //     "Passwor=1234;" +
            //   "Data Source=(DESCRIPTION=" +
            // "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            //"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)) );"; //접속정보 변수저장
            String conninfo = "User Id=ats; " +
                "Password=1234; " +
                "Data Source=(DESCRIPTION =   (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))   (CONNECT_DATA =     (SERVER = DEDICATED)     (SERVICE_NAME = xe)   ) );";
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
                stock_info();
                g_user_id = "";
                g_user_id = axKHOpenAPI1.GetLoginInfo("USER_ID").Trim();

                g_user_name = "";
                g_user_name = axKHOpenAPI1.GetLoginInfo("USER_NAME").Trim();

                txtID.Text = g_user_id;
                txtName.Text = g_user_name;

                l_accno_cnt = "";
                l_accno_cnt = axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT").Trim();
                this.l_accno_cnt = l_accno_cnt; // 조회 form에 데이터 전달

                l_accno_arr = new String[int.Parse(l_accno_cnt)];
                l_accno = "";
                l_accno = axKHOpenAPI1.GetLoginInfo("ACCNO").Trim();
                this.l_acc_no = l_accno;    // 조회 from에 전달할 데이터

                l_accno_arr = l_accno.Split(';');
                this.l_accno_arr = l_accno_arr; // 조회 form에 전달할 데이터

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

            //계좌번호 부분 초기화
            cmbAcnum1.ResetText();
            cmbAcnum1.Items.Clear();

            // chart 부분, list 초기화
            stockList.Items.Clear();
            stockList.ResetText();

            stockChart.Series["chart_data"].Points.Clear();
            stock_name.Text = "";
            current_price.Text = "";
            difference.Text = "";
            start_price.Text = "";
            low_price.Text = "";
            high_price.Text = "";
            total_amount.Text = "";
            year_high.Text = "";
            year_low.Text = "";
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
            l_priority = 0;
            l_buy_amt = 0;
            l_buy_price = 0;
            l_target_price = 0;
            l_cut_loss_price = 0;
            l_buy_trd_yn = "";
            l_sell_trd_yn = "";

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
                //l_seq = 0;

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
                        dataGridView1.Rows.Add(l_arr); //데이터그리드뷰에 추가
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

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
                {
                    continue;
                }
                if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
                {
                    l_jongmok_cd = Row.Cells["JONGMOK_CD"].Value.ToString();
                    l_jongmok_nm = Row.Cells["JONGMOK_NM"].Value.ToString();
                    l_priority = int.Parse(Row.Cells["PRIORITY"].Value.ToString());
                    l_buy_amt = int.Parse(Row.Cells["BUY_AMT"].Value.ToString());
                    l_buy_price = int.Parse(Row.Cells["BUY_PRICE"].Value.ToString());

                    l_target_price = int.Parse(Row.Cells["TARGET_PRICE"].Value.ToString());
                    l_cut_loss_price = int.Parse(Row.Cells["CUT_LOSS_PRICE"].Value.ToString());

                    l_buy_trd_yn = Row.Cells["BUY_TRD_YN"].Value.ToString();
                    l_sell_trd_yn = Row.Cells["SELL_TRD_YN"].Value.ToString();

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
                        MessageBox.Show("삽입 완료");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //에러로그 출력
                    }
                    //메세지로그 출력 코드 
                    conn.Close();


                }
            }

        }

        //종목 수정버튼
        /*
         * DB Commit 기능 추가
         * 수정 후 모든 체크 해제
         */
        
        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd;
            OracleConnection conn;
            OracleTransaction transaction = null;

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
                    transaction = conn.BeginTransaction();

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    cmd.Transaction = transaction;
                    sql = @" UPDATE TB_TRD_JONGMOK
                            SET
                                JONGMOK_NM = " + "'" + l_jongmok_nm + "'" + "," +
                                " PRIORITY = " + l_priority + "," +
                                " BUY_AMT = " + l_buy_amt + "," +
                                " BUY_PRICE = " + l_buy_price + "," +
                                " TARGET_PRICE = " + l_target_price + "," +
                                " CUT_LOSS_PRICE = " + l_cut_loss_price + "," +
                                " BUY_TRD_YN = " + "'" + l_buy_trd_yn + "'" + "," +
                                " SELL_TRD_YN = " + "'" + l_sell_trd_yn + "'" + "," +
                                " UPDT_ID = " + "'" + g_user_id + "'" + "," +
                                " UPDT_DTM = SYSDATE " +
                            "WHERE JONGMOK_CD = " + "'" + l_jongmok_cd + "'" +
                            "AND USER_ID = " + "'" + g_user_id + "'";

                    cmd.CommandText = sql;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Transaction.Commit();
                        MessageBox.Show("수정 성공");
                    }
                    catch (Exception ex)
                    {
                        cmd.Transaction.Rollback();
                        MessageBox.Show("수정 실패" + ex.Message);
                    }
                    //메세지로그 출력 코드 
                    conn.Close();
                }
            }

            // 수정 이후 모든 체크 해제
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(Row.Cells[check.Name].Value))
                {
                    Row.Cells[check.Name].Value = false;
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
                        MessageBox.Show("삭제 완료");
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

        private void stock_info()
        {
            dict = new Dictionary<string, string>();

            string code = axKHOpenAPI1.GetCodeListByMarket("0");
            string[] lst = code.Split(';');
            string name;

            for (int i = 0; i < lst.Length - 1; i++)
            {
                name = axKHOpenAPI1.GetMasterCodeName(lst[i]);
                dict.Add(name, lst[i]);
            }

            var key_list = dict.Keys.ToList();
            key_list.Sort();

            foreach (var key in key_list)
            {
                stockList.Items.Add(key + " (" + dict[key] + ")");
            }
        }

        // 차트를 그리기 위한 데이터 요청
        private void requestChart()
        {
            string code = stockList.SelectedItem.ToString();
            int start = code.LastIndexOf('(');
            int end = code.LastIndexOf(')');
            code = code.Substring(start + 1, end - start - 1);

            string date = DateTime.Now.ToString("yyyyMMdd");
            axKHOpenAPI1.SetInputValue("종목코드", code);
            axKHOpenAPI1.SetInputValue("기준일자", date);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");

            if (nRet != 0)
                MessageBox.Show("차트요청 실패");
        }

        // 주식 정보요청
        private void requestInfo()
        {
            string code = stockList.SelectedItem.ToString();
            int start = code.LastIndexOf('(');
            int end = code.LastIndexOf(')');
            code = code.Substring(start + 1, end - start - 1);

            axKHOpenAPI1.SetInputValue("종목코드", code);
            int iRet = axKHOpenAPI1.CommRqData("종목정보요청", "OPT10001", 0, "1003");

            if (iRet != 0)
                MessageBox.Show("정보요청 실패");

        }
        /* 실시간 데이터 수신 */
        private void axKHOpenAPI1_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            // 현재가
            string cur_price = axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim();
            int c = Int32.Parse(cur_price);
            cur_price = String.Format("{0:C}", Math.Abs(c));


            // 누적 거래량
            string amount = axKHOpenAPI1.GetCommRealData(e.sRealType, 13).Trim();
            amount = String.Format("{0:n0}", Int32.Parse(amount));
            total_amount.Text = amount;

            // 등락율
            string rate = axKHOpenAPI1.GetCommRealData(e.sRealType, 12).Trim();
            double r = Double.Parse(rate);

            // 전일 대비
            string diff = axKHOpenAPI1.GetCommRealData(e.sRealType, 11).Trim();
            int d = Int32.Parse(diff);
            diff = String.Format("{0:C}", Math.Abs(d));

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
        }

        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            // 한번 data 받아서 data 출력
            if (e.sRQName == "종목정보요청")
            {
                string code = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();

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

            else if (e.sRQName == "계좌잔고평가내역")
            {
                acAll = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액"));
                ac = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산"));
                all = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액"));
                allBen = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익"));
            }

            else if(e.sRQName == "종목정보요청")
            {
                int cur_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim()));
            }
            
            // 현재 내 계좌 정보 조회
            else if(e.sRQName == "계좌평가현황요청")
            {
                stock_dict = new Dictionary<string, int>();
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                for(int i = 0; i < nCnt; i++)
                {
                    string name = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    string code = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();
                    int stock_amount = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "보유수량").Trim());
                    stock_dict.Add(name, stock_amount);
                }
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
            // 예외 처리
            if (stockList.Items.Count == 0)
            {
                MessageBox.Show("로그인 후 이용 가능합니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (stockList.SelectedItem == null)
            {
                MessageBox.Show("검색 종목을 선택해 주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            stockChart.Series["chart_data"].Points.Clear();
            priceList = new List<PriceInfo>();
            requestInfo();
            requestChart();

            string d = DateTime.Now.ToString("yyyyMMdd");
            string code = stockList.SelectedItem.ToString().Trim();
            int start = code.LastIndexOf('(');
            int end = code.LastIndexOf(')');
            code = code.Substring(start + 1, end - start - 1);
            axKHOpenAPI1.SetInputValue("종목코드", code);
            axKHOpenAPI1.SetInputValue("기준일자", d);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            // 매수 & 매도 부분에 텍스트 추가
            name_text.Text = axKHOpenAPI1.GetMasterCodeName(code);
            code_text.Text = code;
            price_text.Text = axKHOpenAPI1.GetMasterLastPrice(code).TrimStart('0');

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            if (nRet != 0)
                MessageBox.Show("차트조회 실패");
        }

        /*
        //자동매매
        public void m_thread1()
        {
            string l_cur_tm = null;

            if (g_is_thread == 0)
            {
                g_is_thread = 1;
                MessageBox.Show("자동매매가 시작되었습니다. \n");
            }
            for (; ; )
            {
                l_cur_tm = get_cur_tm();
                if (l_cur_tm.CompareTo("083001") >= 0)
                {
                    //계좌 조회, 계좌정보 조회, 보유종목 매도수문 수행
                }
                if (l_cur_tm.CompareTo("090001") >= 0)
                {
                    for (; ; )
                    {
                        l_cur_tm = get_cur_tm();//현재시각 조회
                        if (l_cur_tm.CompareTo("153001") >= 0)
                        {
                            break;
                        }
                        delay(200);
                    }
                }
                delay(200);
            }
        }
        */

        /* 매수 버튼 클릭 */
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }

            if(code_text.Text == "" || name_text.Text == "" || price_text.Text == "")
            {
                MessageBox.Show("모든 항목을 입력해 주세요");
                return;
            }

            if(buyAmount.Value <= 0)
            {
                MessageBox.Show("올바른 수량을 입력해 주세요");
                return;
            }

            string account = cmbAcnum1.SelectedItem.ToString(); // 계좌번호
            string code = code_text.Text;   // 종목 코드
            int buy_amount = (int)buyAmount.Value;  // 구매량
            int buy_price = Int32.Parse(price_text.Text);   // 구매가

            int result = axKHOpenAPI1.SendOrder("현금매수주문", "5001", account, 1, code, buy_amount, buy_price, "00", "");   // 서버에 주문 요청

            if(result == 0) // 결과가 0인 경우 주문 성공
            {
                write_msg_log("종목명 : " + name_text.Text + ", 수량 : " + buy_amount + ", 가격 : " + buy_price + "]" + " 매수요청\n", 0);
            }
            else
            {
                write_msg_log("주문 확인 요망", 0);
            }
            buyAmount.Value = 0;
            //axKHOpenAPI1.SetInputValue("종목코드", code);
            //axKHOpenAPI1.CommRqData("종목정보요청", "opt10001", 0, "5000");
        }

        /* 매도 버튼 클릭 */
        private void btnAutoEnd_Click(object sender, EventArgs e)
        {

            if(axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }
            if (code_text.Text == "" || name_text.Text == "" || price_text.Text == "")
            {
                MessageBox.Show("모든 항목을 입력해 주세요");
                return;
            }
            if(sellAmount.Value <= 0)
            {
                MessageBox.Show("올바른 수량을 입력해 주세요");
                return;
            }
            
            string account = cmbAcnum1.SelectedItem.ToString(); // 계좌번호
            string code = code_text.Text;   // 종목 코드
            int sell_amount = (int)sellAmount.Value;  // 매도량
            int buy_price = Int32.Parse(price_text.Text);   // 매도가
            axKHOpenAPI1.SetInputValue("계좌번호", account);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int nRet = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "7000");
            int result = axKHOpenAPI1.SendOrder("현금매도주문", "5001", account, 2, code, sell_amount, buy_price, "00", "");   // 서버에 주문 요청
            if(result == 0)
            {
                write_msg_log("종목명 : " + name_text.Text + ", 수량 : " + sell_amount + ", 가격 : " + buy_price + "]" + " 매도요청\n", 0);
            }
            else
            {
                write_msg_log("매도 주문 확인 요망", 0);
            }
            sellAmount.Value = 0;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!");
                return;
            }

            axKHOpenAPI1.SetInputValue("계좌번호", cmbAcnum1.SelectedItem.ToString());
            axKHOpenAPI1.SetInputValue("비밀번호", "0000");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "2");
            axKHOpenAPI1.CommRqData("계좌잔고평가내역", "opw00018", 0, "5000");

            accountForm af = new accountForm(acAll, ac, all, allBen, l_accno_cnt, l_accno_arr, l_acc_no);
            DialogResult dResult = af.ShowDialog();
        }


        // 로그 출력 메소드
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

            if (is_clear == 1)
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.BeginInvoke(new Action(() => textBox1.Clear()));
                }
                else
                {
                    textBox1.Clear();
                }

            }
            else
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.BeginInvoke(new Action(() => textBox1.AppendText(l_cur_dtm + text)));
                }
                else
                {
                    textBox1.AppendText(l_cur_dtm + text);
                }
            }
        }

        // 자동매매 발생 이벤트1
        private void axKHOpenAPI1_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {

            if(e.sGubun == "0")
            {
                write_msg_log("주문 체결 통보", 0);
                write_msg_log("=====================================================\n", 0);
                write_msg_log("주문 구분:" + axKHOpenAPI1.GetChejanData(907) + "\n", 0);
                write_msg_log("체결시간 : " + axKHOpenAPI1.GetChejanData(908) + "\n", 0);
                write_msg_log("종목코드: " + axKHOpenAPI1.GetChejanData(9001) + "\n", 0);
                write_msg_log("종목명: " + axKHOpenAPI1.GetChejanData(302) + "\n", 0);
                write_msg_log("주문수량: " + axKHOpenAPI1.GetChejanData(900) + "\n", 0);
                write_msg_log("체결수량: " + axKHOpenAPI1.GetChejanData(911) + "\n", 0);
                write_msg_log("체결가격 : " + axKHOpenAPI1.GetChejanData(910) + "\n", 0);
                write_msg_log("=====================================================\n", 0);
            }

            else if(e.sGubun == "1")
            {

            }


            /*
            if (e.sGubun == "0")
            {
                String chejan_gb = "";
                chejan_gb = axKHOpenAPI1.GetChejanData(913).Trim();

                if (chejan_gb == "접수")
                {
                    String user_id = null;
                    String jongmok_cd = null;
                    String jongmok_nm = null;
                    String ord_gb = null;
                    String ord_no = null;
                    String org_ord_no = null;
                    string ref_dt = null;
                    int ord_price = 0;
                    int ord_stock_cnt = 0;
                    int ord_amt = 0;
                    String ord_dtm = null;

                    user_id = g_user_id;
                    jongmok_cd = axKHOpenAPI1.GetChejanData(9001).Trim().Substring(1, 6);
                    jongmok_nm = get_jongmok_nm(jongmok_cd);
                    ord_gb = axKHOpenAPI1.GetChejanData(907).Trim();
                    ord_no = axKHOpenAPI1.GetChejanData(9203).Trim();
                    org_ord_no = axKHOpenAPI1.GetChejanData(904).Trim();
                    ord_price = int.Parse(axKHOpenAPI1.GetChejanData(901).Trim());
                    ord_stock_cnt = int.Parse(axKHOpenAPI1.GetChejanData(900).Trim());
                    ord_amt = ord_price * ord_stock_cnt;

                    DateTime CurTime;
                    String CurDt;
                    CurTime = DateTime.Now;
                    CurDt = CurTime.ToString("yyyy") + CurTime.ToString("MM") + CurTime.ToString("dd");

                    ref_dt = CurDt;

                    ord_dtm = CurDt + axKHOpenAPI1.GetChejanData(908).Trim();

                    write_msg_log("종목코드: " + jongmok_cd + "\n", 0);
                    write_msg_log("종목명: " + jongmok_nm + "\n", 0);
                    write_msg_log("주문 구분: " + ord_gb + "\n", 0);
                    write_msg_log("주문 번호: " + ord_no + "\n", 0);
                    write_msg_log("원주문번호: " + org_ord_no + "\n", 0);
                    write_msg_log("주문금액: " + ord_price.ToString() + "\n", 0);
                    write_msg_log("주문주식수: " + ord_stock_cnt.ToString() + "\n", 0);
                    write_msg_log("주문금액: " + ord_amt.ToString() + "\n", 0);
                    write_msg_log("주문일시: " + ord_dtm + "\n", 0);

                    insert_tb_ord_lst(ref_dt, jongmok_cd, jongmok_nm, ord_gb, ord_no, org_ord_no, ord_price, ord_stock_cnt, ord_amt, ord_dtm);

                    if (ord_gb == "2")
                    {
                        updater_tb_accnt(ord_gb, ord_amt);
                    }
                }

                else if (chejan_gb == "체결")
                {
                    String user_id = null;
                    String jongmok_cd = null;
                    String jongmok_nm = null;
                    String chegyul_gb = null;

                    int chegyul_no = 0;
                    int chegyul_price = 0;
                    int chegyul_cnt = 0;
                    int chegyul_amt = 0;

                    String chegyul_dtm = null;
                    String ord_no = null;
                    String org_ord_no = null;
                    String ref_dt = null;

                    user_id = g_user_id;
                    jongmok_cd = axKHOpenAPI1.GetChejanData(9001).Trim().Substring(1, 6);
                    jongmok_nm = get_jongmok_nm(jongmok_cd);

                    chegyul_gb = axKHOpenAPI1.GetChejanData(907).Trim();//2 매수 1 매도
                    chegyul_no = int.Parse(axKHOpenAPI1.GetChejanData(909).Trim());
                    chegyul_price = int.Parse(axKHOpenAPI1.GetChejanData(910).Trim());
                    chegyul_amt = chegyul_price * chegyul_cnt;
                    org_ord_no = axKHOpenAPI1.GetChejanData(904).Trim();

                    DateTime CurTime;
                    String CurDt;
                    CurTime = DateTime.Now;
                    CurDt = CurTime.ToString("yyyy") + CurTime.ToString("MM") + CurTime.ToString("dd");
                    ref_dt = CurDt;
                    chegyul_dtm = CurDt + axKHOpenAPI1.GetChejanData(908).Trim();
                    ord_no = axKHOpenAPI1.GetChejanData(9203).Trim();


                    write_msg_log("종목코드: " + jongmok_cd + "\n", 0);
                    write_msg_log("종목명: " + jongmok_nm + "\n", 0);
                    write_msg_log("체결구분: " + chegyul_gb + "\n", 0);
                    write_msg_log("체결번호: " + chegyul_no.ToString() + "\n", 0);
                    write_msg_log("체결가: " + chegyul_price.ToString() + "\n", 0);
                    write_msg_log("채결주식수: " + chegyul_cnt.ToString() + "\n", 0);
                    write_msg_log("채결금액: " + chegyul_amt.ToString() + "\n", 0);
                    write_msg_log("채결일시: " + chegyul_dtm + "\n", 0);
                    write_msg_log("주문번호: " + ord_no + "\n", 0);
                    write_msg_log("원주문번호: " + org_ord_no + "\n", 0);

                    insert_tb_chegyul_lst(ref_dt, jongmok_cd, jongmok_nm, chegyul_gb, chegyul_no, chegyul_price, chegyul_cnt, chegyul_amt, chegyul_dtm, ord_no, org_ord_no); //체결내역 저장

                    if (chegyul_gb == "1")
                    {
                        updater_tb_accnt(chegyul_gb, chegyul_amt);
                    }
                }
            }

            if (e.sGubun == "1")
            {
                String user_id = null;
                String jongmok_cd = null;

                int boyu_cnt = 0;
                int boyu_price = 0;
                int boyu_amt = 0;

                user_id = g_user_id;
                jongmok_cd = axKHOpenAPI1.GetChejanData(9001).Trim().Substring(1, 6);
                boyu_cnt = int.Parse(axKHOpenAPI1.GetChejanData(930).Trim());
                boyu_price = int.Parse(axKHOpenAPI1.GetChejanData(931).Trim());
                boyu_amt = int.Parse(axKHOpenAPI1.GetChejanData(932).Trim());

                String l_jongmok_nm = null;
                l_jongmok_nm = get_jongmok_nm(jongmok_cd);

                write_msg_log("종목코드: " + jongmok_cd + "\n", 0);
                write_msg_log("보유주식수: " + boyu_cnt.ToString() + "\n", 0);
                write_msg_log("보유가: " + boyu_price.ToString() + "\n", 0);
                write_msg_log("보유금액: " + boyu_amt.ToString() + "\n", 0);

                merge_tb_accnt_info(jongmok_cd, l_jongmok_nm, boyu_cnt, boyu_price, boyu_amt);
            }*/
        }

        
        public void insert_tb_accnt_info(string i_jongmok_cd, string i_jongmok_nm, int i_buy_price, int i_own_stock_cnt, int i_own_amt)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            l_sql = @"insert into tb_accnt_info values (" +
                "'" + g_user_id + "'" + "," +
                "'" + g_accnt_no + "'" + "," +
                "to_char(sysdate,'yyyymmdd')" + "," +
                "'" + i_jongmok_cd + "'" + "," +
                "'" + i_jongmok_nm + "'" + "," +
                +i_buy_price + "," +
                +i_own_stock_cnt + "," +
                +i_own_amt + "," +
                "'ats'" + "," +
                "SYSDATE" + "," +
                "null" + "," +
                "null" + ") ";
            cmd.CommandText = l_sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_msg_log("insert tb accnt info insert tb accnt info ex msg: " + ex.Message + "\n", 0);
            }
        }
        public int get_sell_not_chegyul_ord_stock_cnt(string i_jongmok_cd)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            int l_sell_not_chegyul_ord_stock_cnt = 0;

            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;

            sql = @" select ord_stock_cnt ord_stock_cnt, 
                    ( select nvl(max(b.CHEGYUL_STOCK_CNT),0) CHEGYUL_STOCK_CNT
                    from tb_chegyul_lst b
                    where b.user_id = a.user_id
                    and b.accnt_no = a.accnt_no
                    and b.ref_dt = a.ref_dt
                    and b.jongmok_cd = a.jongmok_cd
                    and b.ord_gb = a.ord_gb
                    and b.ord_no = a.ord_no 
                    ) CHEGYUL_STOCK_CNT
                from TB_ORD_LST a
                where a.ref_dt = TO_CHAR(SYSDATE,'YYYYMMDD')
                and a.user_id = " + "'" + g_user_id + "'" +
                " and a.jongmok_cd = " + "'" + i_jongmok_cd + "'" +
                " and a.ACCNT_NO = " + "'" + g_accnt_no + "'" +
                " and a.ord_gb = '1' " +
                " and a.org_ord_no ='0000000' " +
                " and not exist ( select '1' " +
                "               from TB_ORD_LST b" +
                "               where b.user_id = a.user_id " +
                "               and b.accnt_no = a.accnt_no " +
                "               and b.ref_dt = a.ref_dt" +
                "               and b.jongmok_cd = a.jongmok_cd " +
                "               and b.ord_gb = a.ord_gb " +
                "               and b.org_ord_no = a.ord_no " +
                "               )) ";

            cmd.CommandText = sql;

            reader = cmd.ExecuteReader();

            l_sell_not_chegyul_ord_stock_cnt = int.Parse(reader[0].ToString());//미체결 매도주문 주식수 가져오기

            reader.Close();
            conn.Close();

            return l_sell_not_chegyul_ord_stock_cnt;
        }

        public void merge_tb_accnt_info(String i_jongmok_cd, String i_jongmok_nm, int i_boyu_cnt, int i_boyu_price, int i_boyu_amt)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            //계좌정보 테이블 세팅, 기존에 보유한 종목이면 갱신, 보유하지 않았으면 신규로 삽입
            l_sql = @"merge into TB_ACCNT_INFO a
                    using ( 
                        select nvl(max(user_id),'0') user_id, nvl(max(ref_dt),'0') ref_dt, nvl(max(jongmok_cd), '0') jongmok_cd, nvl(max(jongmok_nm), '0') jongmok_nm
                        from TB_ACCNT_INFO
                        where user_id = '" + g_user_id + "'" +
                        "and ACCNT_NO = '" + g_accnt_no + "'" +
                        "and jongmok_cd = '" + i_jongmok_cd + "'" +
                        "and ref_dt = to_char(sysdate, 'yyyymmdd') " +
                        " )  b" +
                        " on (a.user_id = b.user_id and a.jongmok_cd = b.jongmok_cd and a.ref_dt = b.ref_dt " +
                        "when matched then update " +
                        "set OWN_STOCK_CNT = " + i_boyu_cnt + "," +
                        "BUY_PRICE = " + i_boyu_price + "," +
                        "OWN_AMT = " + i_boyu_amt + "," +
                        "updt_dtm = SYSDATE" + "," +
                        "updt_id = 'ats'" +
                        "when not matched then insert (a.user_id, a.accnt_no, a.ref_dt, a.jongmok_cd, a.jongmok_nm, a.BUY_PRICE, a.OWN_STOCK_CNT, a.OWN_AMT, a.inst_dtm, a.inst_id) values ( " +
                        "'" + g_user_id + "'" + "," +
                        "'" + g_accnt_no + "'" + "," +
                        "to_char(sysdate, 'yyyymmdd'), " +
                        "'" + i_jongmok_cd + "'" + "," +
                        "'" + i_jongmok_nm + "'" + "," +
                        +i_boyu_price + "," +
                        +i_boyu_cnt + "," +
                        +i_boyu_amt + "," +
                        "SYSDATE, " +
                        "'ats'" +
                        " ) ";

            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_msg_log("merge TB ACCNT INFO: " + ex.Message + "\n", 0);
            }
            conn.Close();

        }
        public void insert_tb_ord_lst(string i_ref_dt, String i_jongmok_cd, String i_jongmok_nm, String i_ord_gb, String i_ord_no, String i_org_ord_no, int i_ord_price, int i_ord_stock_cnt, int i_ord_amt, String i_ord_dtm)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            l_sql = @" insert into tb_ord_lst values ( " +
                                "'" + g_user_id + "'" + "," +
                                "'" + g_accnt_no + "'" + "," +
                                "'" + i_ref_dt + "'" + "," +
                                "'" + i_jongmok_cd + "'" + "," +
                                "'" + i_jongmok_nm + "'" + "," +
                                "'" + i_ord_gb + "'" + "," +
                                "'" + i_ord_no + "'" + "," +
                                "'" + i_org_ord_no + "'" + "," +
                                +i_ord_price + "'" +
                                +i_ord_stock_cnt + "'" +
                                +i_ord_amt + "," +
                                "'" + i_ord_dtm + "'" + "," +
                                "'ats'" + "," +
                                "SYSDATE" + "," +
                                "null" + "," +
                                "null" + ") ";
            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                write_msg_log(e.ToString() + "\n", 0);
            }
            conn.Close();
        }
        public void sell_ord_first()//계좌정보 보유종목의 매도주문 메소도
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;

            String sql = null;
            OracleDataReader reader = null;

            string l_jongmok_cd = null;
            int l_buy_price = 0;
            int l_own_stock_cnt = 0;
            int l_target_price = 0;

            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //TB_ACCNT_INFO와 TBTRDJONGMOK 테이블 조인해서 매도 대상 종목 조회

            sql = @" SELECT " +
                "   A.JONGMOK_CD, " +
                "   A.BUY_PRICE, " +
                "   A.OWN_STOCK_CNT, " +
                "   B.TARGET_PRICE " +
                " FROM TB_ACCNT_INFO A, " +
                "   TB_TRD_JONGMOK B " +
                " WHERE A.USER_ID = " + "'" + g_user_id + "'" +
                " AND A.ACCNT_NO = " + "'" + g_accnt_no + "'" +
                " AND A.REF_DT = TO_CHAR(SYSDATE, 'YYYYMMDD') " +
                " AND A.USER_ID = B.USER_ID " +
                " AND A.JONGMOK_CD = B.JONGMOK_CD " +
                " AND B.SELL_TRD_YN = 'Y' AND A.OWN_STOCK_CNT >0 ";

            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_jongmok_cd = "";
                l_buy_price = 0;
                l_own_stock_cnt = 0;
                l_target_price = 0;

                l_jongmok_cd = reader[0].ToString().Trim();
                l_buy_price = int.Parse(reader[1].ToString().Trim());
                l_own_stock_cnt = int.Parse(reader[2].ToString().Trim());
                l_target_price = int.Parse(reader[3].ToString().Trim());

                write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                write_msg_log("매입가: " + l_buy_price.ToString() + "\n", 0);
                write_msg_log("보유주식수: " + l_own_stock_cnt.ToString() + "\n", 0);
                write_msg_log("목표가: " + l_target_price.ToString() + "\n", 0);

                int l_new_target_price = 0;
                l_new_target_price = get_hoga_unit_price(l_target_price, l_jongmok_cd, 0);

                g_flag_4 = 0;
                g_rqname = "매도주문";

                String l_scr_no = null;
                l_scr_no = "";
                //l_scr_no = get_scr_no();

                int ret = 0;

                //매도주문 요청
                ret = axKHOpenAPI1.SendOrder("매도주문", l_scr_no, g_accnt_no, 2, l_jongmok_cd, l_own_stock_cnt, l_new_target_price, "00", "");

                if (ret == 0)
                {
                    write_msg_log("매도주문 Sendord() 호출 성공 \n", 0);
                    write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                }
                else
                {
                    write_msg_log("매도주문 Sendord() 호출 실패 \n", 0);
                    write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                }

                delay(200);

                for (; ; )
                {
                    if (g_flag_4 == 1)
                    {
                        delay(200);
                        axKHOpenAPI1.DisconnectRealData(l_scr_no);
                        break;
                    }
                    else
                    {
                        write_msg_log("'매도주문' 완료 대기 중 ... \n", 0);
                        delay(200);
                        break;
                    }
                }
                axKHOpenAPI1.DisconnectRealData(l_scr_no);
            }
            reader.Close();
            conn.Close();


        }

        public int get_hoga_unit_price(int i_price, String i_jongmok_cd, int i_hoga_unit_jump)
        {
            int l_market_type;
            int l_rest;
            l_market_type = 0;

            try
            {
                l_market_type = int.Parse(axKHOpenAPI1.GetMarketType(i_jongmok_cd).ToString());
            }
            catch (Exception ex)
            {
                write_msg_log("get_hoga_unit_price() ex.Message: " + ex.Message + "\n", 0);
            }
            if (i_price < 1000)
            {
                return i_price + (i_hoga_unit_jump * 1);
            }
            else if (i_price >= 1000 && i_price < 5000)
            {
                l_rest = i_price % 5;
                if (l_rest == 0)
                {
                    return i_price + (i_hoga_unit_jump * 5);
                }
                else if (l_rest == 3)
                {
                    return (i_price - l_rest) + (i_hoga_unit_jump * 5);
                }
                else
                {
                    return (i_price + (5 - l_rest)) + (i_hoga_unit_jump * 5);

                }
            }
            else if (i_price >= 5000 && i_price < 10000)
            {
                l_rest = i_price % 10;
                if (l_rest == 0)
                {
                    return i_price + (i_hoga_unit_jump * 10);
                }
                else if (l_rest < 5)
                {
                    return (i_price - l_rest) + (i_hoga_unit_jump * 10);

                }
                else
                {
                    return (i_price + (10 - l_rest)) + (i_hoga_unit_jump * 10);

                }
            }
            else if (i_price >= 10000 && i_price < 50000)
            {
                l_rest = i_price % 50;
                if (l_rest == 0)
                {
                    return i_price + (i_hoga_unit_jump * 50);

                }
                else if (l_rest < 25)
                {
                    return (i_price - l_rest) + (i_hoga_unit_jump * 50);
                }
                else
                {
                    return (i_price + (50 - l_rest)) + (i_hoga_unit_jump * 50);

                }
            }
            else if (i_price > 50000 && i_price < 100000)
            {
                l_rest = i_price % 100;
                if (l_rest == 0)
                {
                    return i_price + (i_hoga_unit_jump * 100);

                }
                else if (l_rest < 50)
                {
                    return (i_price - l_rest) + (i_hoga_unit_jump * 100);
                }
                else
                {
                    return (i_price + (100 - l_rest)) + (i_hoga_unit_jump * 100);
                }
            }
            else if (i_price > 100000 && i_price < 500000)
            {
                if (l_market_type == 10)
                {
                    l_rest = i_price % 100;
                    if (l_rest == 0)
                    {
                        return i_price + (i_hoga_unit_jump * 100);

                    }
                    else if (l_rest < 50)
                    {
                        return (i_price - l_rest) + (i_hoga_unit_jump * 100);
                    }
                    else
                    {
                        return (i_price + (100 - l_rest)) + (i_hoga_unit_jump * 100);
                    }
                }
                else
                {
                    l_rest = i_price % 500;
                    if (l_rest == 0)
                    {
                        return i_price + (i_hoga_unit_jump * 500);

                    }
                    else if (l_rest < 250)
                    {
                        return (i_price - l_rest) + (i_hoga_unit_jump * 500);
                    }
                    else
                    {
                        return (i_price + (500 - l_rest)) + (i_hoga_unit_jump * 500);
                    }
                }
            }
            else if (i_price > 500000)
            {
                if (l_market_type == 10)
                {
                    l_rest = i_price % 100;
                    if (l_rest == 0)
                    {
                        return i_price + (i_hoga_unit_jump * 100);

                    }
                    else if (l_rest < 50)
                    {
                        return (i_price - l_rest) + (i_hoga_unit_jump * 100);
                    }
                    else
                    {
                        return (i_price + (100 - l_rest)) + (i_hoga_unit_jump * 100);
                    }
                }
                else
                {
                    l_rest = i_price % 1000;
                    if (l_rest == 0)
                    {
                        return i_price + (i_hoga_unit_jump * 1000);

                    }
                    else if (l_rest < 500)
                    {
                        return (i_price - l_rest) + (i_hoga_unit_jump * 1000);
                    }
                    else
                    {
                        return (i_price + (1000 - l_rest)) + (i_hoga_unit_jump * 1000);
                    }
                }

            }
            return 0;
        }
        
        public void insert_tb_chegyul_lst(string i_ref_dt, String i_jongmok_cd, String i_jongmok_nm, String i_chegyul_gb, int i_chegyul_no, int i_chegyul_price, int i_chegyul_stock_cnt, int i_chegyul_amt, String i_chegyul_dtm, String i_ord_no, String i_org_ord_no)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            l_sql = @"insert into tb_chegyul_lst values ( " +
                "'" + g_user_id + "'" + "," +
                "'" + g_accnt_no + "'" + "," +
                "'" + i_ref_dt + "'" + "," +
                "'" + i_jongmok_cd + "'" + "," +
                "'" + i_jongmok_nm + "'" + "," +
                "'" + i_chegyul_gb + "'" + "," +
                +i_chegyul_no + "," +
                +i_chegyul_price + ","
                + i_chegyul_amt + "'" +
                "'" + i_chegyul_dtm + "'" + "," +
                "'ats'" + "," +
                "SYSDATE" + "," +
                "null" + "," +
                "null" + ") ";

            cmd.CommandText = l_sql; ;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_msg_log("insert tb chegyul list ed: " + ex.Message + "\n", 0);
            }
            conn.Close();



        }
        
        public void set_tb_accnt()
        {
            int l_for_cnt = 0;
            int l_for_flag = 0;

            write_msg_log("TB_ACCNT 테이블 세팅 시작\n", 0);

            g_ord_amt_possible = 0;
            l_for_flag = 0;
            for (; ; )
            {
                axKHOpenAPI1.SetInputValue("계좌번호", g_accnt_no);
                axKHOpenAPI1.SetInputValue("비밀번호", "");

                g_rqname = "";
                g_rqname = "증거금세부내역조회요청";//요청명 정의
                g_flag_1 = 0;//요청중

                String l_scr_no = null; //화면번호
                l_scr_no = "";
                //l_scr_no = get_scr_no();
                axKHOpenAPI1.CommRqData("증거금세부내역조회요청", "opw00013", 0, l_scr_no);//open api로 데이터 요청

                l_for_cnt = 0;
                for (; ; )//요청 후 대기 시작
                {
                    if (g_flag_1 == 1)
                    {
                        delay(1000);
                        axKHOpenAPI1.DisconnectRealData(l_scr_no);
                        l_for_flag = 1;
                        break;
                    }
                    else //요청 응답 아직
                    {
                        MessageBox.Show("대기중..");//need to eliminate
                        write_msg_log("'증거금 세부내역조회 요청' 완료 대기 중 시작\n", 0);
                        delay(1000);
                        l_for_cnt++;
                        if (l_for_cnt == 1)
                        {
                            l_for_flag = 9;
                            break;
                        }
                        else
                            continue;
                    }
                    axKHOpenAPI1.DisconnectRealData(l_scr_no);//화면번호 접속해제
                    if (l_for_flag == 1)//요청에 대한 응답 받았으므로 무한루프 빠져나옴
                    {
                        break;
                    }
                    else if (l_for_flag == 0)
                    {
                        delay(1000);
                        break;
                    }
                    delay(1000);
                }
                write_msg_log("주문가능금액: " + g_ord_amt_possible.ToString() + "\n", 0);

                merge_tb_accnt(g_ord_amt_possible);

            }
        }

        public void real_buy_ord()
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            string l_jongmok_cd = null;

            int l_buy_amt = 0;
            int l_buy_price = 0;

            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            //거래 종목 테이블 조회

            sql = @"                " +
                "SELECT             " +
                "   A.JONGMOK_CD,   " +
                "   A.BUY_AMT,      " +
                "   A.BUY_PRICE     " +
                " FROM TB_TRD_JONGMOK A " +
                " WHERE A.USER_ID = " + "'" + g_user_id + "'" +
                " AND A.BUY_TRD_YN = 'Y' " +
                " ORDER BY A.PRIORITY ";

            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_jongmok_cd = "";
                l_buy_amt = 0;
                l_buy_price = 0;

                l_jongmok_cd = reader[0].ToString().Trim();//종목코드
                l_buy_amt = int.Parse(reader[1].ToString().Trim());//매수금액
                l_buy_price = int.Parse(reader[2].ToString().Trim());//매수가

                int l_buy_price_tmp = 0;
                l_buy_price_tmp = 0;
                l_buy_price_tmp = get_hoga_unit_price(l_buy_price, l_jongmok_cd, 1);//매수호가 구하기

                int l_buy_ord_stock_cnt = 0;
                l_buy_ord_stock_cnt = (int)(l_buy_amt / l_buy_price_tmp);//매수주문 주식 수 구하기

                write_msg_log("종목코드: " + l_jongmok_cd.ToString() + "\n", 0);
                write_msg_log("종목명: " + get_jongmok_nm(l_jongmok_cd) + "\n", 0);
                write_msg_log("매수금액: " + l_buy_amt.ToString() + "\n", 0);
                write_msg_log("매수가: " + l_buy_price_tmp.ToString() + "\n", 0);

                int l_own_stock_cnt = 0;
                l_own_stock_cnt = get_own_stock_cnt(l_jongmok_cd);
                write_msg_log("보유주식수 : " + l_own_stock_cnt.ToString() + "\n", 0);

                if (l_own_stock_cnt > 0)
                {
                    write_msg_log("해당 종목을 보유 중이므로 매수하지 않음 \n", 0);
                    continue;
                }

                string l_buy_not_chegyul_yn = null;
                l_buy_not_chegyul_yn = get_buy_not_chegyul_yn(l_jongmok_cd);


                if (l_buy_not_chegyul_yn == "Y")
                {
                    write_msg_log("해당종목에 미체결 매수주문이 있으므로 매수하지 않음 \n", 0);
                    continue;
                }

                //매수주문 전 최우선 매수호가 확인


                int l_for_flag = 0;
                int l_for_cnt = 0;
                l_for_flag = 0;
                g_buy_hoga = 0;

                for (; ; )

                {
                    g_rqname = "";
                    g_rqname = "호가조회";
                    g_flag_7 = 0;
                    axKHOpenAPI1.SetInputValue("종목코드", l_jongmok_cd);

                    string l_scr_no_2 = null;
                    l_scr_no_2 = "";

                    //l_scr_no_2 = get_scr_no();

                    axKHOpenAPI1.CommRqData("호가조회", "opt10004", 0, l_scr_no_2);

                    try
                    {
                        l_for_cnt = 0;
                        for (; ; )
                        {
                            if (g_flag_7 == 1)
                            {
                                delay(200);
                                axKHOpenAPI1.DisconnectRealData(l_scr_no_2);
                                l_for_flag = 1;
                                break;
                            }
                            else
                            {
                                write_msg_log("호가조회 완료 대기중...\n", 0);
                                delay(200);
                                l_for_cnt++;
                                if (l_for_cnt == 5)
                                {
                                    l_for_flag = 0;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        write_msg_log("real buy ord 호가조회 ex.Message: " + ex.Message + "\n", 0);

                    }
                    axKHOpenAPI1.DisconnectRealData(l_scr_no_2);

                    if (l_for_flag == 1)
                    {
                        break;
                    }
                    else if (l_for_flag == 0)
                    {
                        delay(200);
                        continue;
                    }
                    delay(200);
                }

                if (l_buy_price > g_buy_hoga)
                {
                    write_msg_log("해당 종목의 매수가가 최우선 매수호가보다 크므로 매수주문하지 않음 \n", 0);
                    continue;
                }

                g_flag_3 = 0;
                g_rqname = "매수주문";

                String l_scr_no = null;
                l_scr_no = "";
                //l_scr_no = get_scr_no();

                int ret = 0;

                ret = axKHOpenAPI1.SendOrder("매수주문", l_scr_no, g_accnt_no, 1, l_jongmok_cd, l_buy_ord_stock_cnt, l_buy_price, "00", "");
                if (ret == 0)
                {
                    write_msg_log("매수주문 sendorder() 호출 성공\n", 0);
                    write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                }
                else
                {
                    write_msg_log("매수주문 sendorder() 호출 실패\n", 0);
                    write_msg_log("l_jongmok_cd: " + l_jongmok_cd + "\n", 0);
                }
                delay(200);

                for (; ; )
                {
                    if (g_flag_3 == 1)
                    {
                        delay(200);
                        axKHOpenAPI1.DisconnectRealData(l_scr_no);
                        break;
                    }
                    else
                    {
                        write_msg_log("매수주문 완료 대기중...\n", 0);
                        delay(200);
                        break;
                    }
                }


                axKHOpenAPI1.DisconnectRealData(l_scr_no);
                delay(1000);
            }


            reader.Close();
            conn.Close();

        }

        public void real_sell_ord()
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;

            String sql = null;
            OracleDataReader reader = null;

            string l_jongmok_cd = null;
            int l_target_price = 0;
            int l_own_stock_cnt = 0;

            write_msg_log("real_sell_ord 시작 \n", 0);
            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @" SELECT " +
                    "       A.JONGMOK_CD, " +
                    "       A.TARGET_PRICE " +
                    "       B.OWN_STOCK_CNT " +
                    " FROM " +
                    "       TB_TRD_JONGMOK A, " +
                    "       TB_ACCNT_INFO B, " +
                    " WHERE A.USER_ID = " + "'" + g_user_id + "'" +
                    " AND A.JONGMOK_CD = B.JONGMOK_CD " +
                    " AND B.ACCNT_NO " + "'" + g_accnt_no + "'" +
                    " AND B.REF_DT = TO_CHAR(SYSDATE, 'YYYYMMDD')" +
                    " AND A.SELL_TRD_YN = 'Y' AND B.OWN_STOCK_CNT > 0";

            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_jongmok_cd = "";
                l_target_price = 0;

                l_jongmok_cd = reader[0].ToString().Trim();
                l_target_price = int.Parse(reader[1].ToString().Trim());
                l_own_stock_cnt = int.Parse(reader[2].ToString().Trim());

                write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                write_msg_log("종목명: " + get_jongmok_nm(l_jongmok_cd) + "\n", 0);
                write_msg_log("목표가: " + l_target_price.ToString() + "\n", 0);
                write_msg_log("보유주식수: " + l_own_stock_cnt.ToString() + "\n", 0);

                int l_sell_not_chegyul_ord_stock_cnt = 0;
                l_sell_not_chegyul_ord_stock_cnt = get_sell_not_chegyul_ord_stock_cnt(l_jongmok_cd);

                if (l_sell_not_chegyul_ord_stock_cnt == l_own_stock_cnt)//미체결 매도주문 주식수와 보유주식수가 같으면 기 주문종목이므로 매도주문하지 않음
                {
                    continue;
                }
                else//미체결 매도주문 주식소와 보유주식수가 같지 않으면 아직 매도하지 않은 종목임
                {
                    int l_sell_ord_stock_cnt_tmp = 0;
                    l_sell_ord_stock_cnt_tmp = l_own_stock_cnt - l_sell_not_chegyul_ord_stock_cnt;//보유주식수에서 미체결 매도주문 주식수를 빼서 매도주문 주식수를 구함

                    if (l_sell_ord_stock_cnt_tmp <= 0)//매도 대상 주식수가 0 이하라면 매도하지 않음
                    {
                        continue;
                    }
                    int l_new_target_price = 0;
                    l_new_target_price = get_hoga_unit_price(l_target_price, l_jongmok_cd, 0);// 매도호가를 구함

                    g_flag_4 = 0;
                    g_rqname = "매도주문";

                    String l_scr_no = null;
                    l_scr_no = "";
                    //l_scr_no = get_scr_no();

                    int ret = 0;

                    ret = axKHOpenAPI1.SendOrder("매도주문", l_scr_no, g_accnt_no, 2, l_jongmok_cd, l_sell_ord_stock_cnt_tmp, l_new_target_price, "00", "");

                    if (ret == 0)
                    {
                        write_msg_log("매도주문 Sendord() 호출 성공\n", 0);
                        write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                    }
                    else
                    {
                        write_msg_log("매도주문 Sendord() 호출 실패\n", 0);
                        write_msg_log("l_jongmok_cd: " + l_jongmok_cd + "\n", 0);
                    }
                    delay(200);

                    for (; ; )
                    {
                        if (g_flag_4 == 1)
                        {
                            delay(200);
                            axKHOpenAPI1.DisconnectRealData(l_scr_no);
                            break;
                        }
                        else
                        {
                            write_msg_log("'매도주문' 완료 대기중 ...\n", 0);
                            delay(200);
                            break;
                        }
                    }
                    axKHOpenAPI1.DisconnectRealData(l_scr_no);

                }
            }
            reader.Close();
            conn.Close();
        }

        public int get_own_stock_cnt(string i_jongmok_cd)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            int l_own_stock_cnt = 0;
            conn = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @"
                SELEECT
                    NVL(MAX(OWN_STOCK_CNT), 0) OWN_STOCK_CNT
                    FROM
                    TB_ACCNT_INFO
                    WHERE USER_ID = " + "'" + g_user_id + "'" +
                    " AND JONGMOK_CD = " + "'" + i_jongmok_cd + "'" +
                    " AND ACCNT_NO = " + "'" + g_accnt_no + "'" +
                    " AND REF_DT = TO_CHAR(SYSDATE, 'YYYYMMDD') ";

            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();

            l_own_stock_cnt = int.Parse(reader[0].ToString());//보유주식수 구하기

            reader.Close();
            conn.Close();

            return l_own_stock_cnt;
        }
        public string get_buy_not_chegyul_yn(string i_jongmok_cd)//미체결 매수주문 부분 가져오기
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            int l_buy_not_chegyul_ord_stock_cnt = 0;
            string l_buy_not_chegyul_yn = null;

            conn = null;
            cmd = null;

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @"
                select nvl(sum(ord_stock_cnt - CHEGYUL_STOCK_CNT),0) buy_not_chegyul_ord_stock_cnt
                from(select ord_stock_cnt ord_stock_cnt, (select nvl(max(b.CHEGYUL_STOCK_CNT),0) CHEGYUL_STOCK_CNT
                from tb_chegyul_lst b
                where b.user_id = a.user_id
                and b.accnt_no = a.accnt_no
                and b.jongmok_cd = a.jongmok_cd
                and b.ord_gb = a.ord_gb
                and b.ord_no = a.ord_no
                )CHEGYUL_STOCK_CNT
                from
                TB_ORD_LST a
                where a.ref_dt = TO_CHAR(SYSDATE, 'YYYYMMDD'
                and a.user_id " + "'" + g_user_id + "'" +
                " and a.ACCNT_NO = " + "'" + g_accnt_no + "'" +
                " and a.jongmok_cd = " + "'" + i_jongmok_cd + "'" +
                " and a.ord_gb = '2'" +
                " and a.org_ord_no = '0000000' " +
                " and not exists ( select '1' " +
                "                   from TB_ORD_LST b" +
                "                   where b.user_id = a.user_id" +
                "                   and b.accnt_no = a.accnt_no" +
                "                   and b.ref_dt = a.ref_dt" +
                "                   and b.jongmok_cd = a.jongmok_cd" +
                "                   and b.ord_gb = a.ord_gb " +
                "                   and b.org_ord_no = a.ord_no" +
                ")" +
                " ) x";

            cmd.CommandText = sql;

            reader = cmd.ExecuteReader();
            reader.Read();

            l_buy_not_chegyul_ord_stock_cnt = int.Parse(reader[0].ToString());//미체결 매도주문 주식 수 구하기

            reader.Close();
            conn.Close();

            if (l_buy_not_chegyul_ord_stock_cnt > 0)
            {
                l_buy_not_chegyul_yn = "Y";
            }
            else
            {
                l_buy_not_chegyul_yn = "N";
            }
            return l_buy_not_chegyul_yn;

        }

        public void real_cut_loss_ord()//실시간 손절주문 메서드
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            string l_jongmok_cd = null;

            int l_cut_loss_price = 0;
            int l_own_stock_cnt = 0;
            int l_for_flag = 0;
            int l_for_cnt = 0;


            write_msg_log("real_cut_loss_ord 시작\n", 0);
            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @" SELECT " +
                    "   A.JONGMOK_CD, " +
                    "   A.CUT_LOSS_PRICE, " +
                    "   B.OWN_STOCK_CNT " +
                    " FROM " +
                    "   TB_TRD_JONGMOK A, " +
                    "   TB_ACCNT_INFO B " +
                    " WHERE A.USER_ID = " + "'" + g_user_id + "'" +
                    " AND A.JONGMOK_CD = B.JONGMOK_CD " +
                    " AND B.ACCNT_NO = " + "'" + g_accnt_no + "'" +
                    " AND B.REF_DT = TO_CHAR(SYSDATE,'YYYYMMDD') " +
                    " AND A.SELL_TRD_YN  = 'Y' AND B.OWN_STOCK_CNT>0";


            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_jongmok_cd = "";
                l_cut_loss_price = 0;

                l_jongmok_cd = reader[0].ToString().Trim();
                l_cut_loss_price = int.Parse(reader[1].ToString().Trim());
                l_own_stock_cnt = int.Parse(reader[2].ToString().Trim());

                write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                write_msg_log("종목명: " + get_jongmok_nm(l_jongmok_cd) + "\n", 0);
                write_msg_log("손절가: " + l_cut_loss_price.ToString() + "\n", 0);
                write_msg_log("보유주식수: " + l_own_stock_cnt.ToString() + "\n", 0);

            }

            //p.196 현재가 조회
            l_for_flag = 0;
            g_cur_price = 0;
            for (; ; )
            {
                g_rqname = "";
                g_rqname = "현재가조회";
                g_flag_6 = 0;
                axKHOpenAPI1.SetInputValue("종목코드", l_jongmok_cd);

                string l_scr_no = null;
                l_scr_no = "";
                //l_scr_no = get_scr_no();

                axKHOpenAPI1.CommRqData(g_rqname, "opt10001", 0, l_scr_no);
                try
                {
                    l_for_cnt = 0;
                    for (; ; )
                    {
                        if (g_flag_6 == 1)
                        {
                            delay(200);
                            axKHOpenAPI1.DisconnectRealData(l_scr_no);
                            l_for_flag = 1;
                            break;
                        }
                        else
                        {
                            write_msg_log("현재가 조회 완료 대기 중 ... \n", 0);
                            delay(200);
                            l_for_cnt++;
                            if (l_for_cnt == 5)
                            {
                                l_for_flag = 0;
                                break;

                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    write_msg_log("real_cut_loss_ord 현재가조회 ex.Message : " + ex.Message + "\n", 0);

                }
                axKHOpenAPI1.DisconnectRealData(l_scr_no);
                if (l_for_flag == 1)
                {
                    break;
                }
                else if (l_for_flag == 0)
                {
                    delay(200);
                    continue;

                }
                delay(100);

            }




            reader.Close();
            conn.Close();



        }
        public void merge_tb_accnt(int g_ord_amt_possible)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            if (conn != null)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                //계좌정보 테이블 셋팅
                l_sql = @"merge into tb_accnt a
                    using (
                            select nvl (max(user_id,' ') user_id, nvl(max(accnt_no,' ') accnt_no, nvl(max(ref_dt),' ') ref_dt " +
                            "afrom tb_accnt" +
                            "where user_id = '" + g_user_id + "'" +
                            "and accnt_no = " + "'" + g_accnt_no + "'" +
                            "and ref_dt = to_char(sysdate, 'yyyymmdd')" +
                            " ) b " +
                            "on (a.user_id = b.user_id and a.accnt_no = b.accnt_no and a.ref_dt = b.ref_dt)" +
                            " when matched then update " +
                            "set ord_possible_amt = " + g_ord_amt_possible + "," +
                            "updt_dtm = SYSDATE" + "," +
                            "updt_id = 'ats' " +
                            "when not matched then insert(a.user_ID, a.accnt_no, a.ref_dt, a.ord_possible_amt, a.inst_dtm, a.inst_id) values ( " +
                                                                                                                        "'" + g_user_id + "'" + "," +
                                                                                                                        "'" + g_accnt_no + "'" + "," +
                                                                                                                        " to)char(sysdate, 'yyyymmdd')" + "," +
                                                                                                                        +g_ord_amt_possible + "," + "SYSDATE, " +
                                                                                                                        "'ats'" +
                                                                                                                        " )";
                cmd.CommandText = l_sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    write_msg_log("merge_tb_accnt() ex: " + ex.Message + "\n", 0);
                }
                finally
                {
                    conn.Close();
                }

            }
            else
            {
                write_msg_log("db connection check!\n", 0);
            }
        }
        public void updater_tb_accnt(String i_chegyul_gb, int i_chegyul_amt)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            if (i_chegyul_gb == "2")
            {
                l_sql = @" update TB_ACCNT set ORD_POSSIBLE_AMT =  ord_possible_amt -"
       + i_chegyul_amt + ", updt_dtm = SYSDATE, updt_id = 'ats'" +
                   " where user_id =" + "'" + g_user_id + "'" +
                   "and accnt_no = " + "'" + g_accnt_no + "'" +
                   "and ref_dt = to_char(sysdate,'yyyymmdd')";
            }
            else if (i_chegyul_gb == "1")
            {
                l_sql = @" update TB_ACCNT set ORD_POSSIBLE_AMT = ord_possible_amt ="
        + i_chegyul_amt + ",updt_dtm = SYSDATE, updt_id = 'ats'" +
        "where  user_id - " + "'" + g_user_id + "'" +
        "and accnt no = " + "'" + g_user_id + "'" +
        "and ref_dt = to_char(sysdate, 'yyyymmdd')";
            }

            cmd.CommandText = l_sql;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                write_msg_log("update TB_ACCNT ex Message : " + e.Message + "\n", 0);
            }

        }

        public void update_tb_trd_jongmok(String i_jongmok_cd)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            string l_sql = null;
            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            l_sql = @" update TB_TRD_JONGMOK set buy_trd_yn = 'N', updt_dtm =SYSDATE, updt_id = 'ats' " + "where user_id = " + "'" + g_user_id + "'" + " and jongmok_cd = " + "'" + i_jongmok_cd + "'";
            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_msg_log("update TB_TRD_JONGMOK ex.Message: " + ex.Message + "\n", 0);
            }

            conn.Close();
        }

        
        public void set_tb_accnt_info()//계좌정보 테이블 설정
        {
            OracleCommand cmd;
            OracleConnection conn;
            string sql;
            int l_for_cnt = 0;
            int l_for_flag = 0;



            sql = null;
            cmd = null;

            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @"delete from tb_accnt_info where ref_dt = to_char(sysdate, 'yyyymmdd') and user_id = " + "'" + g_user_id + "'";//당일 기준 계좌정보 삭제

            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                write_msg_log("delete tb_accnt_info ex.Message: " + e.Message + "\n", 0);
            }
            conn.Close();

            g_is_next = 0;
            for (; ; )
            {
                l_for_flag = 0;
                for (; ; )
                {
                    axKHOpenAPI1.SetInputValue("계좌번호", g_accnt_no);
                    axKHOpenAPI1.SetInputValue("비밀번호", "");
                    axKHOpenAPI1.SetInputValue("상장폐지조회구분", "1");
                    axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

                    g_flag_2 = 0;

                    g_rqname = "계좌평가현황요청";

                   // String l_scr_no = get_scr_no();

                    //계좌정보 데이터 수신요청

                    //axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", g_is_next, l_scr_no);
                    l_for_cnt = 0;
                    for (; ; )
                    {
                        if (g_flag_2 == 1)
                        {
                            delay(1000);
                            //axKHOpenAPI1.DisconnectRealData(l_scr_no);
                            l_for_flag = 1;
                            break;

                        }
                        else
                        {
                            delay(1000);
                            l_for_cnt++;
                            if (l_for_cnt == 5)
                            {
                                l_for_flag = 0;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                    delay(1000);
                    //axKHOpenAPI1.DisconnectRealData(l_scr_no);
                    if (l_for_flag == 1)
                    {
                        break;
                    }
                    else if (l_for_flag == 0)
                    {
                        delay(1000);
                        continue;
                    }
                }
                if (g_is_next == 0)
                {
                    break;
                }
                delay(1000);
            }



        }

        public void sell_canc_ord(string i_jongmok_cd)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String sql = null;
            OracleDataReader reader = null;

            string l_rid = null;
            string l_jongmok_cd = null;
            int l_ord_stock_cnt = 0;
            int l_ord_price = 0;
            string l_ord_no = null;
            string l_org_ord_no = null;

            conn = null;
            conn = connect_db();

            sql = null;
            cmd = null;
            reader = null;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = @"select
                        rowid rid,
                        jongmok_cd,
                        (ord_stock_cnt -
                        ( select nvl(max(b.CHEGYUL_STOCK_CNT, 0) CHEGYUL_STOCK_CNT
                        from tb_chegyul_lst b
                        where b.user_id = a.userid
                        and b.accnt_no = a.accnt_no
                        and b.ref_dt = a.ref_dt
                        and b.jongmok_cd = a.jongmok_cd
                        and b.ord_gb = a.ord_gb
                        and b.ord_n = a.ord_no
                    )) sell_not_chegyul_ord_stock_cnt,
                        ord_price,
                        ord_no,
                        org_ord_no
                    from
                    TB_ORD_LST a
                    where a.ref_dt = TO_CHAR(SYSDATE, 'YYYYMMDD')
                    and a.user_id =     " + "'" + g_user_id + "'" +
                    " and a.accnt_no      " + "'" + g_accnt_no + "'" +
                    " and a.jongmok_cd      " + "'" + i_jongmok_cd + "'" +
                    " and a.ord_gb = '1' " +
                    " and a.org_ord_no ='0000000'  " +
                    " and not exists ( select '1' " +
                    "                           from TB_ORD_LST b" +
                    "                           where b.user_id = a.user_id " +
                    "                           and b.accnt_no = a.accnt_no" +
                    "                           and b.ref_dt = a.ref_dt" +
                    "                           and b.jongmok_cd = a.jongmok_cd" +
                    "                           and b.ord_gb = a.ord_gb" +
                    "                           and b.org_ord_no = a.ord_no" +
                    "                           )";




            cmd.CommandText = sql; ;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                l_rid = "";
                l_jongmok_cd = "";
                l_ord_stock_cnt = 0;
                l_ord_price = 0;
                l_ord_no = "";
                l_org_ord_no = "";

                l_rid = reader[0].ToString().Trim();
                l_jongmok_cd = reader[1].ToString().Trim();
                l_ord_stock_cnt = int.Parse(reader[2].ToString().Trim());
                l_ord_price = int.Parse(reader[3].ToString().Trim());
                l_ord_no = reader[4].ToString().Trim();
                l_org_ord_no = reader[5].ToString().Trim();

                g_flag_5 = 0;
                g_rqname = "매도주문취소";

                String l_scr_no = null;
                l_scr_no = "";
                //l_scr_no = get_scr_no();

                int ret = 0;
                //매도취소주문 요청
                ret = axKHOpenAPI1.SendOrder("매도취소주문", l_scr_no, g_accnt_no, 4, l_jongmok_cd, l_ord_stock_cnt, 0, "03", l_ord_no);

                if (ret == 0)
                {
                    write_msg_log("매도취소주문 sendord(() 호출 성공 \n", 0);
                    write_msg_log("종목코드: " + l_jongmok_cd + "\n", 0);
                }
                else
                {
                    write_msg_log("매도취소주문 sendord(() 호출 실패 \n", 0);
                    write_msg_log("l jongmok cd: " + l_jongmok_cd + "\n", 0);
                }
                delay(200);

                for (; ; )
                {
                    if (g_flag_5 == 1)
                    {
                        delay(200);
                        axKHOpenAPI1.DisconnectRealData(l_scr_no);
                        break;
                    }
                    else
                    {
                        write_msg_log("매도취소주문 완료 대기중.. \n", 0);
                        delay(200);
                        break;

                    }
                }
                axKHOpenAPI1.DisconnectRealData(l_scr_no);
                delay(1000);
            }
            reader.Close();
            conn.Close();

        }

        private void axKHOpenAPI1_OnReceiveMsg(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            if (e.sRQName == "매수주문")
            {
                write_msg_log("\n======매수주문 원장 응답정보 출력 시작 ======\n", 0);
                write_msg_log("sScrNo: " + e.sScrNo + "\n", 0);
                write_msg_log("sRQName: " + e.sRQName + "\n", 0);
                write_msg_log("sTrCode: " + e.sTrCode + "\n", 0);
                write_msg_log("sMsg: " + e.sMsg + "\n", 0);
                write_msg_log("======매수주문 운장 응답정보 출력 종료======\n", 0);
                g_flag_3 = 1;
            }
            if (e.sRQName == "매도주문")
            {
                write_msg_log("\n======매도주문 원장 응답정보 출력 시작 ======\n", 0);
                write_msg_log("sScrNo: " + e.sScrNo + "\n", 0);
                write_msg_log("sRQName: " + e.sRQName + "\n", 0);
                write_msg_log("sTrCode: " + e.sTrCode + "\n", 0);
                write_msg_log("sMsg: " + e.sMsg + "\n", 0);
                write_msg_log("======매도주문 운장 응답정보 출력 종료======\n", 0);
                g_flag_4 = 1;
            }
            if (e.sRQName == "매도취소주문")
            {
                write_msg_log("\n======매도취소주문 원장 응답정보 출력 시작 ======\n", 0);
                write_msg_log("sScrNo: " + e.sScrNo + "\n", 0);
                write_msg_log("sRQName: " + e.sRQName + "\n", 0);
                write_msg_log("sTrCode: " + e.sTrCode + "\n", 0);
                write_msg_log("sMsg: " + e.sMsg + "\n", 0);
                write_msg_log("======매도취소주문 운장 응답정보 출력 종료======\n", 0);
                g_flag_5 = 1;
            }
        }

        public string get_jongmok_nm(string i_jongmok_cd) //종목코드를 입력값으로 받음
        {
            string l_jongmok_nm = null;

            l_jongmok_nm = axKHOpenAPI1.GetMasterCodeName(i_jongmok_cd);
            return l_jongmok_nm;
        }

        public string get_cur_tm()
        {
            DateTime l_cur_time;
            string l_cur_tm;

            l_cur_time = DateTime.Now; //현재시각을 1_cur_time에 저장
            l_cur_tm = l_cur_time.ToString("HHmmss"); // 시분초를 1_cur_tm에 저장

            return l_cur_tm; //현재시각 리턴
        }
    }
}

