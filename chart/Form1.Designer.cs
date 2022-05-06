
namespace Stock
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stockData = new System.Windows.Forms.ListBox();
            this.stockList = new System.Windows.Forms.ComboBox();
            this.select = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.ListBox();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stockInfo = new System.Windows.Forms.TableLayoutPanel();
            this.start_price = new System.Windows.Forms.Label();
            this.high_price_label = new System.Windows.Forms.Label();
            this.year_high_label = new System.Windows.Forms.Label();
            this.year_low_label = new System.Windows.Forms.Label();
            this.total_amount_label = new System.Windows.Forms.Label();
            this.low_price_label = new System.Windows.Forms.Label();
            this.stock_name = new System.Windows.Forms.Label();
            this.current_price = new System.Windows.Forms.Label();
            this.difference = new System.Windows.Forms.Label();
            this.start_prcie = new System.Windows.Forms.Label();
            this.high_price = new System.Windows.Forms.Label();
            this.low_price = new System.Windows.Forms.Label();
            this.total_amount = new System.Windows.Forms.Label();
            this.year_high = new System.Windows.Forms.Label();
            this.year_low = new System.Windows.Forms.Label();
            this.stock_name_label = new System.Windows.Forms.Label();
            this.current_price_label = new System.Windows.Forms.Label();
            this.difference_label = new System.Windows.Forms.Label();
            this.realtimeData = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.stockInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockData
            // 
            this.stockData.FormattingEnabled = true;
            this.stockData.ItemHeight = 12;
            this.stockData.Location = new System.Drawing.Point(171, 94);
            this.stockData.Name = "stockData";
            this.stockData.Size = new System.Drawing.Size(238, 148);
            this.stockData.TabIndex = 0;
            // 
            // stockList
            // 
            this.stockList.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stockList.FormattingEnabled = true;
            this.stockList.Location = new System.Drawing.Point(171, 67);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(157, 24);
            this.stockList.TabIndex = 1;
            // 
            // select
            // 
            this.select.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.select.Location = new System.Drawing.Point(334, 68);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 2;
            this.select.Text = "조회";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(12, 67);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(72, 23);
            this.login.TabIndex = 3;
            this.login.Text = "로그인";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(90, 67);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 4;
            this.logout.Text = "로그아웃";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.ItemHeight = 12;
            this.status.Location = new System.Drawing.Point(12, 96);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(153, 148);
            this.status.TabIndex = 6;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(12, 24);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(83, 32);
            this.axKHOpenAPI1.TabIndex = 7;
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI1_OnReceiveTrData);
            this.axKHOpenAPI1.OnReceiveRealData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEventHandler(this.axKHOpenAPI1_OnReceiveRealData);
            this.axKHOpenAPI1.OnEventConnect += new AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI1_OnEventConnect);
            // 
            // stockChart
            // 
            chartArea2.AxisX.IsReversed = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.stockChart.Legends.Add(legend2);
            this.stockChart.Location = new System.Drawing.Point(426, 132);
            this.stockChart.Name = "stockChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series2.Legend = "Legend1";
            series2.Name = "chart_data";
            series2.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series2);
            this.stockChart.Size = new System.Drawing.Size(668, 365);
            this.stockChart.TabIndex = 8;
            this.stockChart.Text = "chart1";
            this.stockChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.stockChart_AxisViewChanged);
            // 
            // stockInfo
            // 
            this.stockInfo.ColumnCount = 6;
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.stockInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.stockInfo.Controls.Add(this.start_price, 2, 0);
            this.stockInfo.Controls.Add(this.high_price_label, 2, 1);
            this.stockInfo.Controls.Add(this.year_high_label, 4, 1);
            this.stockInfo.Controls.Add(this.year_low_label, 4, 2);
            this.stockInfo.Controls.Add(this.total_amount_label, 4, 0);
            this.stockInfo.Controls.Add(this.low_price_label, 2, 2);
            this.stockInfo.Controls.Add(this.stock_name, 1, 0);
            this.stockInfo.Controls.Add(this.current_price, 1, 1);
            this.stockInfo.Controls.Add(this.difference, 1, 2);
            this.stockInfo.Controls.Add(this.start_prcie, 3, 0);
            this.stockInfo.Controls.Add(this.high_price, 3, 1);
            this.stockInfo.Controls.Add(this.low_price, 3, 2);
            this.stockInfo.Controls.Add(this.total_amount, 5, 0);
            this.stockInfo.Controls.Add(this.year_high, 5, 1);
            this.stockInfo.Controls.Add(this.year_low, 5, 2);
            this.stockInfo.Controls.Add(this.stock_name_label, 0, 0);
            this.stockInfo.Controls.Add(this.current_price_label, 0, 1);
            this.stockInfo.Controls.Add(this.difference_label, 0, 2);
            this.stockInfo.Location = new System.Drawing.Point(426, 24);
            this.stockInfo.Name = "stockInfo";
            this.stockInfo.RowCount = 3;
            this.stockInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.stockInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.stockInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.stockInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.stockInfo.Size = new System.Drawing.Size(668, 100);
            this.stockInfo.TabIndex = 9;
            // 
            // start_price
            // 
            this.start_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_price.AutoSize = true;
            this.start_price.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_price.Location = new System.Drawing.Point(283, 0);
            this.start_price.Name = "start_price";
            this.start_price.Size = new System.Drawing.Size(61, 33);
            this.start_price.TabIndex = 3;
            this.start_price.Text = "시가";
            this.start_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // high_price_label
            // 
            this.high_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.high_price_label.AutoSize = true;
            this.high_price_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.high_price_label.Location = new System.Drawing.Point(283, 33);
            this.high_price_label.Name = "high_price_label";
            this.high_price_label.Size = new System.Drawing.Size(61, 33);
            this.high_price_label.TabIndex = 4;
            this.high_price_label.Text = "상한가";
            this.high_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_high_label
            // 
            this.year_high_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high_label.AutoSize = true;
            this.year_high_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.year_high_label.Location = new System.Drawing.Point(476, 33);
            this.year_high_label.Name = "year_high_label";
            this.year_high_label.Size = new System.Drawing.Size(80, 33);
            this.year_high_label.TabIndex = 7;
            this.year_high_label.Text = "52주최고";
            this.year_high_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low_label
            // 
            this.year_low_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low_label.AutoSize = true;
            this.year_low_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.year_low_label.Location = new System.Drawing.Point(476, 66);
            this.year_low_label.Name = "year_low_label";
            this.year_low_label.Size = new System.Drawing.Size(80, 34);
            this.year_low_label.TabIndex = 8;
            this.year_low_label.Text = "52주최저";
            this.year_low_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_amount_label
            // 
            this.total_amount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total_amount_label.AutoSize = true;
            this.total_amount_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.total_amount_label.Location = new System.Drawing.Point(476, 0);
            this.total_amount_label.Name = "total_amount_label";
            this.total_amount_label.Size = new System.Drawing.Size(80, 33);
            this.total_amount_label.TabIndex = 6;
            this.total_amount_label.Text = "거래량";
            this.total_amount_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // low_price_label
            // 
            this.low_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.low_price_label.AutoSize = true;
            this.low_price_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.low_price_label.Location = new System.Drawing.Point(283, 66);
            this.low_price_label.Name = "low_price_label";
            this.low_price_label.Size = new System.Drawing.Size(61, 34);
            this.low_price_label.TabIndex = 5;
            this.low_price_label.Text = "하한가";
            this.low_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stock_name
            // 
            this.stock_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_name.AutoSize = true;
            this.stock_name.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stock_name.Location = new System.Drawing.Point(88, 0);
            this.stock_name.Name = "stock_name";
            this.stock_name.Size = new System.Drawing.Size(189, 33);
            this.stock_name.TabIndex = 15;
            this.stock_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // current_price
            // 
            this.current_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.current_price.AutoSize = true;
            this.current_price.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.current_price.Location = new System.Drawing.Point(88, 33);
            this.current_price.Name = "current_price";
            this.current_price.Size = new System.Drawing.Size(189, 33);
            this.current_price.TabIndex = 16;
            this.current_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difference
            // 
            this.difference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difference.AutoSize = true;
            this.difference.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.difference.Location = new System.Drawing.Point(88, 66);
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(189, 34);
            this.difference.TabIndex = 17;
            this.difference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_prcie
            // 
            this.start_prcie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_prcie.AutoSize = true;
            this.start_prcie.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start_prcie.Location = new System.Drawing.Point(350, 0);
            this.start_prcie.Name = "start_prcie";
            this.start_prcie.Size = new System.Drawing.Size(120, 33);
            this.start_prcie.TabIndex = 18;
            this.start_prcie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // high_price
            // 
            this.high_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.high_price.AutoSize = true;
            this.high_price.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.high_price.Location = new System.Drawing.Point(350, 33);
            this.high_price.Name = "high_price";
            this.high_price.Size = new System.Drawing.Size(120, 33);
            this.high_price.TabIndex = 18;
            this.high_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // low_price
            // 
            this.low_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.low_price.AutoSize = true;
            this.low_price.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.low_price.Location = new System.Drawing.Point(350, 66);
            this.low_price.Name = "low_price";
            this.low_price.Size = new System.Drawing.Size(120, 34);
            this.low_price.TabIndex = 18;
            this.low_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_amount
            // 
            this.total_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total_amount.AutoSize = true;
            this.total_amount.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.total_amount.Location = new System.Drawing.Point(562, 0);
            this.total_amount.Name = "total_amount";
            this.total_amount.Size = new System.Drawing.Size(103, 33);
            this.total_amount.TabIndex = 18;
            this.total_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_high
            // 
            this.year_high.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high.AutoSize = true;
            this.year_high.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.year_high.Location = new System.Drawing.Point(562, 33);
            this.year_high.Name = "year_high";
            this.year_high.Size = new System.Drawing.Size(103, 33);
            this.year_high.TabIndex = 18;
            this.year_high.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low
            // 
            this.year_low.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low.AutoSize = true;
            this.year_low.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.year_low.Location = new System.Drawing.Point(562, 66);
            this.year_low.Name = "year_low";
            this.year_low.Size = new System.Drawing.Size(103, 34);
            this.year_low.TabIndex = 18;
            this.year_low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stock_name_label
            // 
            this.stock_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_name_label.AutoSize = true;
            this.stock_name_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stock_name_label.Location = new System.Drawing.Point(3, 0);
            this.stock_name_label.Name = "stock_name_label";
            this.stock_name_label.Size = new System.Drawing.Size(79, 33);
            this.stock_name_label.TabIndex = 19;
            this.stock_name_label.Text = "종목명";
            this.stock_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // current_price_label
            // 
            this.current_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.current_price_label.AutoSize = true;
            this.current_price_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.current_price_label.Location = new System.Drawing.Point(3, 33);
            this.current_price_label.Name = "current_price_label";
            this.current_price_label.Size = new System.Drawing.Size(79, 33);
            this.current_price_label.TabIndex = 20;
            this.current_price_label.Text = "현재가";
            this.current_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difference_label
            // 
            this.difference_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difference_label.AutoSize = true;
            this.difference_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.difference_label.Location = new System.Drawing.Point(3, 66);
            this.difference_label.Name = "difference_label";
            this.difference_label.Size = new System.Drawing.Size(79, 34);
            this.difference_label.TabIndex = 21;
            this.difference_label.Text = "전일대비";
            this.difference_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // realtimeData
            // 
            this.realtimeData.FormattingEnabled = true;
            this.realtimeData.ItemHeight = 12;
            this.realtimeData.Location = new System.Drawing.Point(12, 271);
            this.realtimeData.Name = "realtimeData";
            this.realtimeData.Size = new System.Drawing.Size(397, 220);
            this.realtimeData.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "실시간";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.realtimeData);
            this.Controls.Add(this.stockInfo);
            this.Controls.Add(this.stockChart);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.login);
            this.Controls.Add(this.select);
            this.Controls.Add(this.stockList);
            this.Controls.Add(this.stockData);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            this.stockInfo.ResumeLayout(false);
            this.stockInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox stockData;
        private System.Windows.Forms.ComboBox stockList;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.ListBox status;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
        private System.Windows.Forms.TableLayoutPanel stockInfo;
        private System.Windows.Forms.Label start_price;
        private System.Windows.Forms.Label low_price_label;
        private System.Windows.Forms.Label high_price_label;
        private System.Windows.Forms.Label year_high_label;
        private System.Windows.Forms.Label year_low_label;
        private System.Windows.Forms.Label total_amount_label;
        private System.Windows.Forms.Label stock_name;
        private System.Windows.Forms.Label current_price;
        private System.Windows.Forms.Label difference;
        private System.Windows.Forms.Label start_prcie;
        private System.Windows.Forms.Label high_price;
        private System.Windows.Forms.Label low_price;
        private System.Windows.Forms.Label total_amount;
        private System.Windows.Forms.Label year_high;
        private System.Windows.Forms.Label year_low;
        private System.Windows.Forms.Label stock_name_label;
        private System.Windows.Forms.Label current_price_label;
        private System.Windows.Forms.Label difference_label;
        private System.Windows.Forms.ListBox realtimeData;
        private System.Windows.Forms.Label label1;
    }
}

