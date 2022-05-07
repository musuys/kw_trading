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


namespace eungsosil

{
    public partial class Form1 : Form
    {
        string g_user_id = null;
        string g_accnt_no = null;
        string g_user_name = null;

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

            String user_name = null; // 유저이름
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

        //증권계좌번호
        private void cmbAcnum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //g_accnt_no = ComboBox1.SelectedItem.ToString().Trim();
            //write_msg_log("사용할 증권계좌번호는 ; [" + g_accnt_no + "] 입니다. \n", 0);
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
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
    }
}
