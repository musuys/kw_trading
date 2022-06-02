using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;
using AxKHOpenAPILib;
namespace eungsosil

{
    public partial class Form1 : Form
    {
        string g_user_id = null;
        string g_accnt_no = null;
        string g_user_name = null;
        List<PriceInfo> priceList;
        Dictionary<string, string> dict = new Dictionary<string, string>(); // 코드명, 주식이름 저장 dict
        Dictionary<string, int> stock_dict; // 보유 주식 현황 확인  dict
        accountForm af; // 새로운 form 띄우기

        /* 자동매매 변수 추가 */
        string acAll;
        string ac;
        string all;
        string allBen;
        string money_amount;

        string l_accno_cnt;
        string l_acc_no;
        string[] l_accno_arr;

        public Form1()
        {
            InitializeComponent();

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
                        Application.DoEvents();
                    }
                }
                catch (AccessViolationException ex)
                {
                    write_msg_log("오류 발생");
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


            string l_accno = null;//증권계좌번호
            string l_accno_cnt = null;//소유한 증권계좌번호수
            string[] l_accno_arr = null;//N개의 증권계좌번호를 저장할 배열

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
                axKHOpenAPI1.KOA_Functions("ShowAccountWindow", "");

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
                getAccountInfo();
                getTotalInfo();
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

        /* 차트 */
        class PriceInfo
        {
            public string date { get; set; }
            public int initial_price { get; set; }
            public int high_price { get; set; }
            public int low_price { get; set; }
            public int end_price { get; set; }
        }

        // 주식 List 생성
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

            else if (e.sRQName == "계좌평가잔고내역요청")
            {
                acAll = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액");
                all = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액");
                allBen = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익금액");
                ac = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총수익률(%)");
            }

            else if (e.sRQName == "종목정보요청")
            {
                int cur_price = Math.Abs(Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim()));
            }

            // 현재 내 계좌 정보 조회
            else if (e.sRQName == "계좌평가현황요청")
            {
                stock_dict = new Dictionary<string, int>();
                dataGridView1.Rows.Clear();
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                money_amount = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예수금");
                money_amount = string.Format("{0:C}", Int32.Parse(money_amount));

                for (int i = 0; i < nCnt; i++)
                {
                    string name = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim();
                    string code = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목코드").Trim();
                    int stock_amount = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "보유수량"));
                    string stock_amt = string.Format("{0:#,0}", stock_amount);

                    string average_price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "평균단가");
                    average_price = string.Format("{0:C}", Int32.Parse(average_price));

                    string buy_price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "매입금액");
                    buy_price = string.Format("{0:C}", Int32.Parse(buy_price));

                    string result_price = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "평가금액");
                    result_price = string.Format("{0:C}", Int32.Parse(result_price));

                    string lost_profit_amount = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "손익금액");
                    lost_profit_amount = string.Format("{0:C}", Int32.Parse(lost_profit_amount));

                    string lost_profit_rate = (Double.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "손익율")) / 10000).ToString();
                    lost_profit_rate = string.Format("{0:0.00}", Double.Parse(lost_profit_rate)) + "%";

                    string today_sell = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "금일매도수량");
                    today_sell = string.Format("{0:#,0}", Int32.Parse(today_sell));

                    string today_buy = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "금일매수수량");
                    today_buy = string.Format("{0:#,0}", Int32.Parse(today_buy));

                    stock_dict.Add(name, stock_amount);

                    dataGridView1.Rows.Add(
                        (i + 1).ToString(), name, stock_amt, 
                        average_price, buy_price, result_price, lost_profit_amount, 
                        lost_profit_rate, today_buy, today_sell); 
                }

                // 매도 매수 부분 텍스트 입력
                string stock_code = stockList.SelectedItem.ToString().Trim();
                int start = stock_code.LastIndexOf('(');
                int end = stock_code.LastIndexOf(')');
                stock_code = stock_code.Substring(start + 1, end - start - 1);

                name_text.Text = axKHOpenAPI1.GetMasterCodeName(stock_code);
                code_text.Text = stock_code;
                price_text.Text = axKHOpenAPI1.GetMasterLastPrice(stock_code).TrimStart('0');

                if (!stock_dict.ContainsKey(name_text.Text))
                    stock_amount.Text = "0";
                else
                    stock_amount.Text = stock_dict[name_text.Text].ToString();
            }
        }

        // 실시간 차트 업데이트를 위해 같은 같은 캔들 차트 사용 판단
        bool is_Same_CandleData(string date)
        {
            string now_time = DateTime.Now.ToString("yyyyMMdd");
            return date == now_time;
        }

        // 차트 축 변경시 발생하는 이벤트
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

        // 정보조회 버튼 클릭
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
            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            if (nRet != 0)
                MessageBox.Show("차트조회 실패");

            string account = cmbAcnum1.SelectedItem.ToString();
            axKHOpenAPI1.SetInputValue("계좌번호", account);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            int result = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "7000");
            if (result != 0)
                MessageBox.Show("계좌정보 조회 실패!");
        }

        /* 매수 버튼 클릭 */
        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (code_text.Text == "" || name_text.Text == "" || price_text.Text == "")
            {
                MessageBox.Show("모든 항목을 입력해 주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (buyAmount.Value <= 0)
            {
                MessageBox.Show("올바른 수량을 입력해 주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string account = cmbAcnum1.SelectedItem.ToString(); // 계좌번호
            string code = code_text.Text;   // 종목 코드
            int buy_amount = (int)buyAmount.Value;  // 구매량
            int buy_price = Int32.Parse(price_text.Text);   // 구매가

            int result = axKHOpenAPI1.SendOrder("현금매수주문", "5001", account, 1, code, buy_amount, buy_price, "00", "");   // 서버에 주문 요청

            if (result == 0) // 결과가 0인 경우 주문 성공
            {
                write_msg_log("[종목명 : " + name_text.Text + ", 수량 : " + buy_amount + ", 가격 : " + buy_price + "]" + " 매수요청");
            }
            else
            {
                write_msg_log("주문 확인 요망");
            }

            buyAmount.Value = 0;

            axKHOpenAPI1.SetInputValue("계좌번호", cmbAcnum1.SelectedItem.ToString());
            axKHOpenAPI1.SetInputValue("비밀번호", "0000");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "2");

            int nRet = axKHOpenAPI1.CommRqData("계좌평가잔고내역요청", "opw00018", 0, "5000");
        }

        /* 매도 버튼 클릭 */
        private void btnAutoEnd_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (code_text.Text == "" || name_text.Text == "" || price_text.Text == "")
            {
                MessageBox.Show("모든 항목을 입력해 주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sellAmount.Value <= 0)
            {
                MessageBox.Show("올바른 수량을 입력해 주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string account = cmbAcnum1.SelectedItem.ToString(); // 계좌번호
            string code = code_text.Text;   // 종목 코드
            int sell_amount = (int)sellAmount.Value;  // 매도량
            int buy_price = Int32.Parse(price_text.Text);   // 매도가

            if (Int32.Parse(stock_amount.Text) == 0)
            {
                MessageBox.Show("계좌에 존재하지 않는 종목입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Int32.Parse(stock_amount.Text) < (int)sellAmount.Value)
            {
                MessageBox.Show("매도수량이 보유량보다 많습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int result = axKHOpenAPI1.SendOrder("현금매도주문", "5001", account, 2, code, sell_amount, buy_price, "00", "");   // 서버에 주문 요청

            if (result == 0)
            {
                write_msg_log("종목명 : " + name_text.Text + ", 수량 : " + sell_amount + ", 가격 : " + buy_price + "]" + " 매도요청");
            }
            else
            {
                write_msg_log("매도 주문 확인 요망");
            }
            sellAmount.Value = 0;

            axKHOpenAPI1.SetInputValue("계좌번호", cmbAcnum1.SelectedItem.ToString());
            axKHOpenAPI1.SetInputValue("비밀번호", "0000");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "2");

            int nRet = axKHOpenAPI1.CommRqData("계좌평가잔고내역요청", "opw00018", 0, "5000");
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() != 1)
            {
                MessageBox.Show("로그인 후 이용해주세요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            getTotalInfo();
            accountForm af = new accountForm(money_amount, acAll, all, allBen, ac, l_accno_cnt, l_accno_arr, l_acc_no);
            DialogResult dResult = af.ShowDialog();
        }


        // 로그 출력 메소드
        public void write_msg_log(string text)
        {
            DateTime l_cur_time;
            string l_cur_dt;
            string l_cur_tm;
            string l_cur_dtm;

            l_cur_dt = "";
            l_cur_tm = "";

            l_cur_time = DateTime.Now;
            l_cur_dt = l_cur_time.ToString("yyyy-") + l_cur_time.ToString("MM-") + l_cur_time.ToString("dd");

            l_cur_tm = l_cur_time.ToString("HH:mm:ss");
            l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";

            status.Items.Add(l_cur_dtm + text);
        }

        // 자동매매 발생 이벤트1
        private void axKHOpenAPI1_OnReceiveChejanData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            if (e.sGubun == "0")
            {
                string type = axKHOpenAPI1.GetChejanData(913).Trim();
                string gb = axKHOpenAPI1.GetChejanData(907).Trim();

                if (gb == "1")
                    gb = "매도";
                else if (gb == "2")
                    gb = "매수";

                if (type == "체결")
                {
                    write_msg_log("주문 체결 통보");
                    write_msg_log("주문 구분:" + gb + "\n"); // 1 : 매도, 2 : 매수
                    write_msg_log("종목명: " + axKHOpenAPI1.GetChejanData(302));
                    write_msg_log("주문수량: " + axKHOpenAPI1.GetChejanData(900));
                    write_msg_log("체결수량: " + axKHOpenAPI1.GetChejanData(911));
                    write_msg_log("체결가격 : " + axKHOpenAPI1.GetChejanData(910));
                    status.Items.Add("=====================================================");
                    status.Items.Add("");

                    axKHOpenAPI1.SetInputValue("계좌번호", cmbAcnum1.SelectedItem.ToString());
                    axKHOpenAPI1.SetInputValue("비밀번호", "");
                    axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
                    axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
                    int nRet = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "7001");
                }
            }

            else if (e.sGubun == "1")
            {
                write_msg_log("잔고 통보");
                write_msg_log("종목명: " + axKHOpenAPI1.GetChejanData(302) + "\n");
                write_msg_log("보유수량: " + axKHOpenAPI1.GetChejanData(930));
                stock_amount.Text = axKHOpenAPI1.GetChejanData(930);
                status.Items.Add("");
            }
        }

        public void getAccountInfo()
        {
            string account = cmbAcnum1.SelectedItem.ToString();
            axKHOpenAPI1.SetInputValue("계좌번호", account);
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");

            int result = axKHOpenAPI1.CommRqData("계좌평가현황요청", "OPW00004", 0, "7000");
            if (result != 0)
                MessageBox.Show("계좌정보 조회 실패!");
        }

        public void getTotalInfo()
        {
            axKHOpenAPI1.SetInputValue("계좌번호", cmbAcnum1.SelectedItem.ToString());
            axKHOpenAPI1.SetInputValue("비밀번호", "0000");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "2");

            int result = axKHOpenAPI1.CommRqData("계좌평가잔고내역요청", "opw00018", 0, "5000");
        }
    }
}

