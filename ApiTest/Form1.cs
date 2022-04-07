using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ApiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axKHOpenAPI1.CommConnect();
            axKHOpenAPI1.OnEventConnect += onEventConnect;
            StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create, FileAccess.ReadWrite));
            string info = "ra1019,5678";
            sw.WriteLine(info);
            sw.Close();
        }
        public void onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if(e.nErrCode == 0)
            {
                string code_list = axKHOpenAPI1.GetCodeListByMarket("0");
                string[] code = code_list.Split(';');
                for(int i = 0; i < code.Length; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1["CodeList_code", i].Value = code[i];
                    dataGridView1["Codelist_name", i].Value = axKHOpenAPI1.GetMasterCodeName(code[i]);
                }
            }
        }
    }
}
