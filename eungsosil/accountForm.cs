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
        }
        int g_flag_1 = 0;
        string g_rqname = null;
        int g_ord_amt_possible = 0; //총매수가능금액

        int g_scr_no = 0; //open Api 요청번호

        private string get_scr_no()
        {
            if (g_scr_no < 9999)
                g_scr_no++;
            else
                g_scr_no = 1000;

            return g_scr_no.ToString();
        }

        public void set_tb_accnt()
        {
            int l_for_cnt = 0;  
            int l_for_flag = 0;

            g_ord_amt_possible = 0;

            l_for_flag = 0;
            for (; ; )
            {
                axKHOpenAPI1.SetInputValue("계좌번호", axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT").Trim());
                axKHOpenAPI1.SetInputValue("비밀번호", "");

                g_rqname = "";
                g_rqname = "증거금세부내역조회요청";
                g_flag_1 = 0;

                String l_scr_no = null;
                l_scr_no = "";
                l_scr_no = get_scr_no();
                axKHOpenAPI1.CommRqData("증거금셋부내역조회요청", "opw00013", 0, l_scr_no);
                l_for_cnt = 0;
                for(; ; )
                {
                    if(g_flag_1 == 1)
                    {
                        delay(1000);
                        axKHOpenAPI1.DisconnectRealData(l_scr_no);
                        l_for_flag = 1;
                        break;
                    }else
                    {
                        MessageBox.Show("가져오는 중");
                        delay(1000);
                        l_for_cnt++;
                        if (l_for_cnt == 1)
                        {
                            l_for_flag = 0;
                            break;
                        }
                        else
                            continue;
                    }
                }
                axKHOpenAPI1.DisconnectRealData(l_scr_no);
                if(l_for_flag==1)
                {
                    break;
                }else if(l_for_flag==0)
                {
                    delay(1000);
                    break;
                }
                delay(1000);
                MessageBox.Show("가져오기 성공\n");
            }


        }

        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {

        }
    }
}
