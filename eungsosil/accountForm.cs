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
using AxKHOpenAPILib;

namespace eungsosil
{
    public partial class accountForm : Form

    {


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


        public accountForm()
        {
            InitializeComponent();
            InitializeInfo();
            axKHOpenAPI1.OnEventConnect += onEventConnect;
            btnAccount.Click += acbtn;
            axKHOpenAPI1.OnReceiveTrData += onReceiveTrData;            

            
        }

        private void onReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if(e.sRQName == "계좌잔고평가내역")
            {
                int acAll = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액"));
                int ac = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산"));
                int all = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액"));
                int allBen = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익"));

                textBox2.Text = acAll.ToString() ;
                textBox3.Text = ac.ToString();
                textBox4.Text = all.ToString();
                textBox5.Text = all.ToString()+"";


            }

        }

        private void acbtn(object sender, EventArgs e)
        {
            string acNum = combox1.Text;
            axKHOpenAPI1.SetInputValue("계좌번호", acNum);
            axKHOpenAPI1.SetInputValue("비밀번호", "5934");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "2");

            axKHOpenAPI1.CommRqData("계좌잔고평가내역", "opw00018", 0, "5000");


        }

        private void onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                string ac = axKHOpenAPI1.GetLoginInfo("ACCLIST").Trim();
                string[] acList = ac.Split(';');

                for (int i = 0; i < acList.Length; i++)
                {
                    combox1.Items.Add(acList[i]);
                }
            }
        }

        private void InitializeInfo()
        {
            //계좌번호 출력
            l_accno_cnt = "";
            l_accno_cnt = axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT").Trim();

            l_accno_arr = new String[int.Parse(l_accno_cnt)];
            l_accno = "";
            l_accno = axKHOpenAPI1.GetLoginInfo("ACCNO").Trim();

            l_accno_arr = l_accno.Split(';');

            combox1.Items.Clear();
            combox1.Items.AddRange(l_accno_arr);
            combox1.SelectedIndex = 0;
            g_accnt_no = combox1.SelectedItem.ToString().Trim();
            

        }


        int g_flag_1 = 0;
        string g_rqname = null;
        int g_ord_amt_possible = 0; //총매수가능금액
        string g_accnt_no = null;


        String user_name = null; // 유저이름
        String l_accno = null;//증권계좌번호
        String l_accno_cnt = null;//소유한 증권계좌번호수
        String[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

        int g_scr_no = 0; //open Api 요청번호


        private string get_scr_no()
        {
            if (g_scr_no < 9999)
                g_scr_no++;
            else
                g_scr_no = 1000;

            return g_scr_no.ToString();


        }


        

        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
