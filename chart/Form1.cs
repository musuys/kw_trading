using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock
{
    public partial class Form1 : Form
    {
        List<PriceInfo> priceList;
        class PriceInfo
        {
            public string date { get; set; }
            public int initial_price { get; set; }
            public int high_price { get; set; }
            public int low_price { get; set; }
            public int end_price { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            //chartSeries = stockChart.Series["Series1"];
            //stockChart.Series["Series1"]["PriceUpColor"] = "Red";
            //stockChart.Series["Series1"]["PriceDownColor"] = "Blue";
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.CommConnect() == 0)
                status.Items.Add("로그인 시작");
            else
                status.Items.Add("로그인 실패");
        }

        // 로그인 상태 전달
        private void axKHOpenAPI1_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                status.Items.Add("로그인 성공");
                if (axKHOpenAPI1.GetConnectState() == 1)
                {
                    status.Items.Add("접속상태:연결중");
                    string l = axKHOpenAPI1.GetCodeListByMarket("0");
                    string[] lst = l.Split(';');
                    for(int i = 0; i < lst.Length; i++)
                        stockList.Items.Add(lst[i]);

                }
                else if (axKHOpenAPI1.GetConnectState() == 0)
                    status.Items.Add("접속상태:미연결");
            }
            else
            {
                status.Items.Add("로그인 실패");
            }
        }

        // 차트를 그리기 위해 데이터 요청
        private void requestChart()
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            axKHOpenAPI1.SetInputValue("기준일자", date);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");

            if (nRet == 0)
                status.Items.Add("주식 일봉 정보요청 성공");
            else
                status.Items.Add("주식 일봉 정보요청 실패");
        }
        
        // 주식 정보요청
        private void requestInfo()
        {
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            int iRet = axKHOpenAPI1.CommRqData("종목정보요청", "OPT10001", 0, "1003");

            if (iRet == 0)
                status.Items.Add("정보요청 성공");
            else
                status.Items.Add("정보요청 실패");
        }

        // CommRqData에서 데이터 받아서 차트에 추가
        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "종목정보요청")
            {
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

                stockData.Items.Add(name);
                stockData.Items.Add(cur_price);
                stockData.Items.Add(init_price);
                stockData.Items.Add(diff);
                stockData.Items.Add(high);
                stockData.Items.Add(low);
                stockData.Items.Add(amount);
                stockData.Items.Add(highest);
                stockData.Items.Add(lowest);
                stockData.Items.Add(rate);
                stockData.Items.Add("-----------");

                stock_name.Text = name;
                if (d == 0)
                    current_price.ForeColor = Color.Gray;
                else if (c > 0)
                    current_price.ForeColor = Color.Red;
                else if(c < 0)
                    current_price.ForeColor = Color.Blue;
                current_price.Text = cur_price;

                if (Double.Parse(rate) < 0)
                    difference.ForeColor = Color.Blue;
                else if (Double.Parse(rate) > 0)
                    difference.ForeColor = Color.Red;
                else
                    difference.ForeColor = Color.Gray;
                difference.Text = diff + " | " + rate + "%";

                start_prcie.Text = init_price;
                high_price.Text = high;
                low_price.Text = low;
                total_amount.Text = amount;
                year_high.Text = highest;
                year_low.Text = lowest;
            }

            else if (e.sRQName == "주식일봉차트조회")
            {
                int count = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                for (int i = 0; i < count; i++)
                {
                    priceList.Add(new PriceInfo()
                    {
                        date = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "일자").Trim(),
                        initial_price = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가").Trim()),
                        high_price = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가").Trim()),
                        low_price = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가").Trim()),
                        end_price = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim()),
                    });
                    stockChart.Series["Series1"].Points.AddXY(priceList[i].date, priceList[i].high_price);
                    stockChart.Series["Series1"].Points[i].YValues[1] = priceList[i].low_price;
                    stockChart.Series["Series1"].Points[i].YValues[2] = priceList[i].initial_price;
                    stockChart.Series["Series1"].Points[i].YValues[3] = priceList[i].end_price;
                }

                // AxisViewChanged이후 zoom을 Reset해서 차트 X, Y 비율 조정
                int max = priceList.Max(m => m.high_price);
                int min = priceList.Min(n => n.low_price);
                stockChart.ChartAreas[0].AxisY.Maximum = max;
                stockChart.ChartAreas[0].AxisY.Minimum = min;
                stockChart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                /*
                for (int i = 0; i < count; i++)
                {
                    stockData.Items.Add(idx++);
                    stockData.Items.Add("일자 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "일자"));
                    stockData.Items.Add("현재가 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가"));
                    stockData.Items.Add("거래량 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "거래량"));
                    stockData.Items.Add("시가 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가"));
                    stockData.Items.Add("고가 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가"));
                    stockData.Items.Add("저가 " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가"));
                    stockData.Items.Add("-------------------------------구분선-------------------------------");
                    stockData.SelectedIndex = stockData.Items.Count - 1;
                }
                */
            }
        }

        // 조회 버튼 클릭시 차트 요청
        private void select_Click(object sender, EventArgs e)
        {
            stockChart.Series["Series1"].Points.Clear();
            priceList = new List<PriceInfo>();
            requestInfo();
            requestChart();
            string d = DateTime.Now.ToString("yyyyMMdd");
            axKHOpenAPI1.SetInputValue("종목코드", stockList.SelectedItem.ToString().Trim());
            axKHOpenAPI1.SetInputValue("기준일자", d);
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");

            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            if (nRet == 0)
                status.Items.Add("요청 성공");
            else
                status.Items.Add("요청 실패");
        }

        private void logout_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
            status.Items.Add("로그아웃");
        }


        // 차트 확대 및 축소 시 차트 축 비율 맞추기
        private void stockChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
            int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

            int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
            int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;

            for(int i = startPosition - 1; i < endPosition; i++)
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
    }
}
