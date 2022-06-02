using System;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace eungsosil
{
    public partial class accountForm : Form

    {
        string g_accnt_no;

        // form1 에서 받는 데이터 저장
        string acAll; // 전체매입
        string ac; // 전체평가
        string all;    // 전체손해
        string allBen; // 수익률
        string money;   // 예수금

        string l_accno;
        string l_accno_cnt;//소유한 증권계좌번호수
        string[] l_accno_arr;//N개의 증권계좌번호를 저장할 배열

        public accountForm(string total_money, string accAll, string ac, string all, string allBen, string l_accno_cnt, string[] l_accno_arr, string l_acc_no)
        {
            InitializeComponent();
            money = total_money;
            acAll = string.Format("{0:C}", Int32.Parse(accAll));
            this.ac = string.Format("{0:C}", Int32.Parse(ac));
            this.all = string.Format("{0:C}", Int32.Parse(all));
            this.allBen = Double.Parse(allBen).ToString() + "%";
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

        private void btnAccount_Click(object sender, EventArgs e)
        {
            string acNum = combox1.Text;
            money_text.Text = money;
            textBox3.Text = acAll;   // 전체매입
            textBox4.Text = ac;  // 전체 평가
            textBox5.Text = all; // 전체 손해
            rate_text.Text = allBen; // 수익률
        }
    }
}
