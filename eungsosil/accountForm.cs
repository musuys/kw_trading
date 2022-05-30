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
        //int g_ord_amt_possible = 0; //총매수가능금액
        string g_accnt_no;

        // form1 에서 받는 데이터 저장
        int acAll;
        int ac; // 예수금
        int all;    // 전체 매입금액
        int allBen; // 전체 평가금액

        string l_accno;
        string l_accno_cnt = null;//소유한 증권계좌번호수
        string[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

        int g_scr_no = 0; //open Api 요청번호

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
                        Application.DoEvents();
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


        public accountForm(int accAll, int ac, int all, int allBen, string l_accno_cnt, string[] l_accno_arr, string l_acc_no)
        {
            InitializeComponent();

            acAll = accAll;
            this.ac = ac;
            this.all = all;
            this.allBen = allBen;
            this.l_accno_cnt = l_accno_cnt;
            this.l_accno_arr = l_accno_arr;
            l_accno = l_acc_no;

            InitializeInfo();
        }

        private void InitializeInfo()
        {
            combox1.Items.Clear();
            combox1.Items.AddRange(l_accno_arr);
            combox1.SelectedIndex = 0;
            g_accnt_no = combox1.SelectedItem.ToString().Trim();
        }

        private string get_scr_no()
        {
            if (g_scr_no < 9999)
                g_scr_no++;
            else
                g_scr_no = 1000;

            return g_scr_no.ToString();


        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            string acNum = combox1.Text;
            textBox2.Text = ac.ToString();
            textBox3.Text = all.ToString();
            textBox4.Text = allBen.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
