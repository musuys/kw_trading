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

        // CommRqData에서 초기 한번 수행
        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            // 한번 data 받아서 data 출력
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

                status.Items.Add("주식 TR정보 요청 성공");
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

                status.Items.Add("일봉차트조회 성공");
            }
        }

        // 실시간 차트 업데이트를 위해 같은 같은 캔들 차트 사용 판단
        bool is_Same_CandleData(string date)
        {
            string now_time = DateTime.Now.ToString("yyyyMMdd");
            return date == now_time;
        }

        // 조회 버튼 클릭시 차트 요청
        private void select_Click(object sender, EventArgs e)
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
            if (nRet == 0)
                status.Items.Add("요청 성공");
            else
                status.Items.Add("요청 실패");
        }

        private void logout_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
            status.Items.Add("로그아웃");
            Close();
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

        // 첫 조회 이후 계속해서 해당 주식관련 정보를 실시간으로 get & 갱신
        private void axKHOpenAPI1_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            realtimeData.Items.Add("종목코드\n" + e.sRealKey.Trim());
            realtimeData.Items.Add("실제 타입\n" + e.sRealType.Trim());
            realtimeData.Items.Add("실시간데이터\n" + e.sRealData.Trim());

            // 현재가
            string cur_price = axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim();
            int c = Int32.Parse(cur_price);
            cur_price = String.Format("{0:C}", Math.Abs(c));


            // 누적 거래량
            string amount =axKHOpenAPI1.GetCommRealData(e.sRealType, 13).Trim();
            amount = String.Format("{0:n0}", Int32.Parse(amount));

            // 등락율
            string rate = axKHOpenAPI1.GetCommRealData(e.sRealType, 12).Trim();
            double r = Double.Parse(rate);

            // 전일 대비
            string diff = axKHOpenAPI1.GetCommRealData(e.sRealType, 11).Trim();
            int d = Int32.Parse(diff);
            diff = String.Format("{0:C}", Math.Abs(d));


            // 상한가
            string max = high_price.Text;
            max = max.Substring(1);
            max = max.Replace(",", "");

            if (c > Int32.Parse(max))
            {
                max = Convert.ToString(c);
                high_price.Text = String.Format("{0:C}", max);
            }

            // 하한가
            string min = low_price.Text;
            min = min.Substring(1);
            min = min.Replace(",", "");

            if(Math.Abs(c) < Int32.Parse(min))
            {
                min = Convert.ToString(Math.Abs(c));
                low_price.Text = String.Format("{0:C}", min);
            }

            // 52주 최고
            string year_max = year_high.Text;
            year_max = year_max.Substring(1);
            year_max = year_max.Replace(",", "");

            if(c > Int32.Parse(year_max))
            {
                year_max = Convert.ToString(c);
                year_high.Text = String.Format("{0:C}", year_max);
            }

            //52주 최저
            string year_min = year_low.Text;
            year_min = year_min.Substring(1);
            year_min = year_min.Replace(",", "");

            if(Math.Abs(c) < Int32.Parse(year_min))
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
    }
}
