
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stockData = new System.Windows.Forms.ListBox();
            this.stockList = new System.Windows.Forms.ComboBox();
            this.select = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.ListBox();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // stockData
            // 
            this.stockData.FormattingEnabled = true;
            this.stockData.ItemHeight = 12;
            this.stockData.Location = new System.Drawing.Point(171, 130);
            this.stockData.Name = "stockData";
            this.stockData.Size = new System.Drawing.Size(238, 364);
            this.stockData.TabIndex = 0;
            // 
            // stockList
            // 
            this.stockList.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stockList.FormattingEnabled = true;
            this.stockList.Location = new System.Drawing.Point(171, 102);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(157, 24);
            this.stockList.TabIndex = 1;
            // 
            // select
            // 
            this.select.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.select.Location = new System.Drawing.Point(334, 102);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 2;
            this.select.Text = "조회";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(12, 101);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(72, 23);
            this.login.TabIndex = 3;
            this.login.Text = "로그인";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(90, 101);
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
            this.status.Location = new System.Drawing.Point(12, 130);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(153, 364);
            this.status.TabIndex = 6;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(12, 47);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(83, 32);
            this.axKHOpenAPI1.TabIndex = 7;
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI1_OnReceiveTrData);
            this.axKHOpenAPI1.OnEventConnect += new AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI1_OnEventConnect);
            // 
            // stockChart
            // 
            chartArea1.AxisX.IsReversed = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(415, 130);
            this.stockChart.Name = "stockChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series1);
            this.stockChart.Size = new System.Drawing.Size(674, 365);
            this.stockChart.TabIndex = 8;
            this.stockChart.Text = "chart1";
            this.stockChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.stockChart_AxisViewChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 509);
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
            this.ResumeLayout(false);

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
    }
}

