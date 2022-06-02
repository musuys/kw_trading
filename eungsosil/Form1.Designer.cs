
namespace eungsosil
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAccount = new System.Windows.Forms.Button();
            this.cmbAcnum1 = new System.Windows.Forms.ComboBox();
            this.lblAcnum1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnAutoEnd = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stockList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stock_amount = new System.Windows.Forms.TextBox();
            this.price_text = new System.Windows.Forms.TextBox();
            this.lblCurPrice = new System.Windows.Forms.Label();
            this.lblEventname = new System.Windows.Forms.Label();
            this.buyAmount = new System.Windows.Forms.NumericUpDown();
            this.sellAmount = new System.Windows.Forms.NumericUpDown();
            this.name_text = new System.Windows.Forms.TextBox();
            this.code_text = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stock_name_label = new System.Windows.Forms.Label();
            this.stock_name = new System.Windows.Forms.Label();
            this.start_price_label = new System.Windows.Forms.Label();
            this.start_price = new System.Windows.Forms.Label();
            this.total_amount_label = new System.Windows.Forms.Label();
            this.current_price_label = new System.Windows.Forms.Label();
            this.current_price = new System.Windows.Forms.Label();
            this.high_price_label = new System.Windows.Forms.Label();
            this.high_price = new System.Windows.Forms.Label();
            this.year_high_label = new System.Windows.Forms.Label();
            this.difference_label = new System.Windows.Forms.Label();
            this.difference = new System.Windows.Forms.Label();
            this.low_price_label = new System.Windows.Forms.Label();
            this.low_price = new System.Windows.Forms.Label();
            this.year_low_label = new System.Windows.Forms.Label();
            this.total_amount = new System.Windows.Forms.Label();
            this.year_high = new System.Windows.Forms.Label();
            this.year_low = new System.Windows.Forms.Label();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.status = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.average_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit_loss_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.today_buy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.today_sell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buyAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellAmount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.로그아웃ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1539, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(68, 24);
            this.mnuLogin.Text = "로그인";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAccount);
            this.groupBox1.Controls.Add(this.cmbAcnum1);
            this.groupBox1.Controls.Add(this.lblAcnum1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1539, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(843, 18);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(97, 32);
            this.btnAccount.TabIndex = 7;
            this.btnAccount.Text = "계좌정보";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // cmbAcnum1
            // 
            this.cmbAcnum1.FormattingEnabled = true;
            this.cmbAcnum1.Location = new System.Drawing.Point(529, 22);
            this.cmbAcnum1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAcnum1.Name = "cmbAcnum1";
            this.cmbAcnum1.Size = new System.Drawing.Size(287, 23);
            this.cmbAcnum1.TabIndex = 3;
            // 
            // lblAcnum1
            // 
            this.lblAcnum1.AutoSize = true;
            this.lblAcnum1.Location = new System.Drawing.Point(455, 28);
            this.lblAcnum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcnum1.Name = "lblAcnum1";
            this.lblAcnum1.Size = new System.Drawing.Size(77, 15);
            this.lblAcnum1.TabIndex = 2;
            this.lblAcnum1.Text = "계좌번호 :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(315, 22);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(114, 25);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(225, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "사용자이름 :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(73, 22);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(129, 25);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 28);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(62, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "아이디 :";
            // 
            // btnAutoEnd
            // 
            this.btnAutoEnd.Location = new System.Drawing.Point(733, 45);
            this.btnAutoEnd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutoEnd.Name = "btnAutoEnd";
            this.btnAutoEnd.Size = new System.Drawing.Size(90, 92);
            this.btnAutoEnd.TabIndex = 6;
            this.btnAutoEnd.Text = "매도";
            this.btnAutoEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAutoEnd.UseVisualStyleBackColor = false;
            this.btnAutoEnd.Click += new System.EventHandler(this.btnAutoEnd_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(625, 45);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(90, 92);
            this.btnAuto.TabIndex = 5;
            this.btnAuto.Text = "매수";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.dataGridView1);
            this.grp2.Controls.Add(this.statusStrip1);
            this.grp2.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp2.Location = new System.Drawing.Point(0, 145);
            this.grp2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.grp2.Size = new System.Drawing.Size(561, 508);
            this.grp2.TabIndex = 3;
            this.grp2.TabStop = false;
            this.grp2.Text = "거래종목";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.jongmok_nm,
            this.amount,
            this.average_price,
            this.buy_price,
            this.profit,
            this.profit_amount,
            this.profit_loss_rate,
            this.today_buy,
            this.today_sell});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(8, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(545, 448);
            this.dataGridView1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(8, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(545, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(156, 20);
            this.toolStripStatusLabel1.Text = "주식프로그램접속중....";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.stockList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 123);
            this.panel1.TabIndex = 5;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(610, 46);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(90, 30);
            this.searchBtn.TabIndex = 20;
            this.searchBtn.Text = "정보조회";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "종목코드 검색 :";
            // 
            // stockList
            // 
            this.stockList.FormattingEnabled = true;
            this.stockList.Location = new System.Drawing.Point(262, 49);
            this.stockList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(325, 23);
            this.stockList.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stock_amount);
            this.groupBox2.Controls.Add(this.btnAutoEnd);
            this.groupBox2.Controls.Add(this.price_text);
            this.groupBox2.Controls.Add(this.btnAuto);
            this.groupBox2.Controls.Add(this.lblCurPrice);
            this.groupBox2.Controls.Add(this.lblEventname);
            this.groupBox2.Controls.Add(this.buyAmount);
            this.groupBox2.Controls.Add(this.sellAmount);
            this.groupBox2.Controls.Add(this.name_text);
            this.groupBox2.Controls.Add(this.code_text);
            this.groupBox2.Controls.Add(this.lblBuyPrice);
            this.groupBox2.Controls.Add(this.lblNum);
            this.groupBox2.Controls.Add(this.lblSelect);
            this.groupBox2.Controls.Add(this.lblCode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(978, 168);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매매";
            // 
            // stock_amount
            // 
            this.stock_amount.Location = new System.Drawing.Point(409, 44);
            this.stock_amount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stock_amount.Name = "stock_amount";
            this.stock_amount.ReadOnly = true;
            this.stock_amount.Size = new System.Drawing.Size(183, 25);
            this.stock_amount.TabIndex = 13;
            // 
            // price_text
            // 
            this.price_text.Location = new System.Drawing.Point(130, 112);
            this.price_text.Margin = new System.Windows.Forms.Padding(2);
            this.price_text.Name = "price_text";
            this.price_text.Size = new System.Drawing.Size(185, 25);
            this.price_text.TabIndex = 0;
            // 
            // lblCurPrice
            // 
            this.lblCurPrice.AutoSize = true;
            this.lblCurPrice.Location = new System.Drawing.Point(51, 115);
            this.lblCurPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurPrice.Name = "lblCurPrice";
            this.lblCurPrice.Size = new System.Drawing.Size(77, 15);
            this.lblCurPrice.TabIndex = 12;
            this.lblCurPrice.Text = "희망가격 :";
            // 
            // lblEventname
            // 
            this.lblEventname.AutoSize = true;
            this.lblEventname.Location = new System.Drawing.Point(51, 82);
            this.lblEventname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventname.Name = "lblEventname";
            this.lblEventname.Size = new System.Drawing.Size(77, 15);
            this.lblEventname.TabIndex = 10;
            this.lblEventname.Text = "종목이름 :";
            // 
            // buyAmount
            // 
            this.buyAmount.Location = new System.Drawing.Point(410, 80);
            this.buyAmount.Margin = new System.Windows.Forms.Padding(2);
            this.buyAmount.Name = "buyAmount";
            this.buyAmount.Size = new System.Drawing.Size(183, 25);
            this.buyAmount.TabIndex = 9;
            // 
            // sellAmount
            // 
            this.sellAmount.Location = new System.Drawing.Point(410, 112);
            this.sellAmount.Margin = new System.Windows.Forms.Padding(2);
            this.sellAmount.Name = "sellAmount";
            this.sellAmount.Size = new System.Drawing.Size(183, 25);
            this.sellAmount.TabIndex = 8;
            // 
            // name_text
            // 
            this.name_text.Location = new System.Drawing.Point(130, 78);
            this.name_text.Margin = new System.Windows.Forms.Padding(2);
            this.name_text.Name = "name_text";
            this.name_text.ReadOnly = true;
            this.name_text.Size = new System.Drawing.Size(185, 25);
            this.name_text.TabIndex = 7;
            // 
            // code_text
            // 
            this.code_text.Location = new System.Drawing.Point(130, 45);
            this.code_text.Margin = new System.Windows.Forms.Padding(2);
            this.code_text.Name = "code_text";
            this.code_text.ReadOnly = true;
            this.code_text.Size = new System.Drawing.Size(185, 25);
            this.code_text.TabIndex = 6;
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(333, 118);
            this.lblBuyPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(77, 15);
            this.lblBuyPrice.TabIndex = 5;
            this.lblBuyPrice.Text = "매도수량 :";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(333, 82);
            this.lblNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(77, 15);
            this.lblNum.TabIndex = 4;
            this.lblNum.Text = "매수수량 :";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(334, 51);
            this.lblSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(77, 15);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "현보유량 :";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(51, 48);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(77, 15);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "종목코드 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stockChart);
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 168);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(978, 620);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "차트";
            // 
            // stockChart
            // 
            chartArea4.AxisX.IsReversed = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea4);
            this.stockChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.stockChart.Legends.Add(legend4);
            this.stockChart.Location = new System.Drawing.Point(2, 145);
            this.stockChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockChart.Name = "stockChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series4.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series4.Legend = "Legend1";
            series4.Name = "chart_data";
            series4.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series4);
            this.stockChart.Size = new System.Drawing.Size(974, 473);
            this.stockChart.TabIndex = 19;
            this.stockChart.Text = "chart1";
            this.stockChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.stockChart_AxisViewChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.tableLayoutPanel1.Controls.Add(this.stock_name_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stock_name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.start_price_label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.start_price, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.total_amount_label, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.current_price_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.current_price, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.high_price_label, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.high_price, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.year_high_label, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.difference_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.difference, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.low_price_label, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.low_price, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.year_low_label, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.total_amount, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.year_high, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.year_low, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // stock_name_label
            // 
            this.stock_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_name_label.AutoSize = true;
            this.stock_name_label.Location = new System.Drawing.Point(3, 0);
            this.stock_name_label.Name = "stock_name_label";
            this.stock_name_label.Size = new System.Drawing.Size(125, 41);
            this.stock_name_label.TabIndex = 0;
            this.stock_name_label.Text = "종목명 (종목코드)";
            this.stock_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stock_name
            // 
            this.stock_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_name.AutoSize = true;
            this.stock_name.Location = new System.Drawing.Point(134, 0);
            this.stock_name.Name = "stock_name";
            this.stock_name.Size = new System.Drawing.Size(176, 41);
            this.stock_name.TabIndex = 1;
            this.stock_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_price_label
            // 
            this.start_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_price_label.AutoSize = true;
            this.start_price_label.Location = new System.Drawing.Point(316, 0);
            this.start_price_label.Name = "start_price_label";
            this.start_price_label.Size = new System.Drawing.Size(82, 41);
            this.start_price_label.TabIndex = 2;
            this.start_price_label.Text = "시가";
            this.start_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_price
            // 
            this.start_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_price.AutoSize = true;
            this.start_price.Location = new System.Drawing.Point(404, 0);
            this.start_price.Name = "start_price";
            this.start_price.Size = new System.Drawing.Size(161, 41);
            this.start_price.TabIndex = 3;
            this.start_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_amount_label
            // 
            this.total_amount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total_amount_label.AutoSize = true;
            this.total_amount_label.Location = new System.Drawing.Point(571, 0);
            this.total_amount_label.Name = "total_amount_label";
            this.total_amount_label.Size = new System.Drawing.Size(87, 41);
            this.total_amount_label.TabIndex = 4;
            this.total_amount_label.Text = "거래량";
            this.total_amount_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // current_price_label
            // 
            this.current_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.current_price_label.AutoSize = true;
            this.current_price_label.Location = new System.Drawing.Point(3, 41);
            this.current_price_label.Name = "current_price_label";
            this.current_price_label.Size = new System.Drawing.Size(125, 41);
            this.current_price_label.TabIndex = 6;
            this.current_price_label.Text = "현재가";
            this.current_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // current_price
            // 
            this.current_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.current_price.AutoSize = true;
            this.current_price.Location = new System.Drawing.Point(134, 41);
            this.current_price.Name = "current_price";
            this.current_price.Size = new System.Drawing.Size(176, 41);
            this.current_price.TabIndex = 7;
            this.current_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // high_price_label
            // 
            this.high_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.high_price_label.AutoSize = true;
            this.high_price_label.Location = new System.Drawing.Point(316, 41);
            this.high_price_label.Name = "high_price_label";
            this.high_price_label.Size = new System.Drawing.Size(82, 41);
            this.high_price_label.TabIndex = 8;
            this.high_price_label.Text = "상한가";
            this.high_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // high_price
            // 
            this.high_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.high_price.AutoSize = true;
            this.high_price.Location = new System.Drawing.Point(404, 41);
            this.high_price.Name = "high_price";
            this.high_price.Size = new System.Drawing.Size(161, 41);
            this.high_price.TabIndex = 9;
            this.high_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_high_label
            // 
            this.year_high_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high_label.AutoSize = true;
            this.year_high_label.Location = new System.Drawing.Point(571, 41);
            this.year_high_label.Name = "year_high_label";
            this.year_high_label.Size = new System.Drawing.Size(87, 41);
            this.year_high_label.TabIndex = 10;
            this.year_high_label.Text = "52주최고";
            this.year_high_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difference_label
            // 
            this.difference_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difference_label.AutoSize = true;
            this.difference_label.Location = new System.Drawing.Point(3, 82);
            this.difference_label.Name = "difference_label";
            this.difference_label.Size = new System.Drawing.Size(125, 43);
            this.difference_label.TabIndex = 12;
            this.difference_label.Text = "전일대비";
            this.difference_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difference
            // 
            this.difference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difference.AutoSize = true;
            this.difference.Location = new System.Drawing.Point(134, 82);
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(176, 43);
            this.difference.TabIndex = 13;
            this.difference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // low_price_label
            // 
            this.low_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.low_price_label.AutoSize = true;
            this.low_price_label.Location = new System.Drawing.Point(316, 82);
            this.low_price_label.Name = "low_price_label";
            this.low_price_label.Size = new System.Drawing.Size(82, 43);
            this.low_price_label.TabIndex = 14;
            this.low_price_label.Text = "하한가";
            this.low_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // low_price
            // 
            this.low_price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.low_price.AutoSize = true;
            this.low_price.Location = new System.Drawing.Point(404, 82);
            this.low_price.Name = "low_price";
            this.low_price.Size = new System.Drawing.Size(161, 43);
            this.low_price.TabIndex = 15;
            this.low_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low_label
            // 
            this.year_low_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low_label.AutoSize = true;
            this.year_low_label.Location = new System.Drawing.Point(571, 82);
            this.year_low_label.Name = "year_low_label";
            this.year_low_label.Size = new System.Drawing.Size(87, 43);
            this.year_low_label.TabIndex = 16;
            this.year_low_label.Text = "52주최저";
            this.year_low_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_amount
            // 
            this.total_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total_amount.AutoSize = true;
            this.total_amount.Location = new System.Drawing.Point(664, 0);
            this.total_amount.Name = "total_amount";
            this.total_amount.Size = new System.Drawing.Size(307, 41);
            this.total_amount.TabIndex = 17;
            this.total_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_high
            // 
            this.year_high.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high.AutoSize = true;
            this.year_high.Location = new System.Drawing.Point(664, 41);
            this.year_high.Name = "year_high";
            this.year_high.Size = new System.Drawing.Size(307, 41);
            this.year_high.TabIndex = 18;
            this.year_high.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low
            // 
            this.year_low.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low.AutoSize = true;
            this.year_low.Location = new System.Drawing.Point(664, 82);
            this.year_low.Name = "year_low";
            this.year_low.Size = new System.Drawing.Size(307, 43);
            this.year_low.TabIndex = 19;
            this.year_low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(1952, 0);
            this.axKHOpenAPI1.Margin = new System.Windows.Forms.Padding(2);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(421, 210);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI1_OnReceiveTrData);
            this.axKHOpenAPI1.OnReceiveRealData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEventHandler(this.axKHOpenAPI1_OnReceiveRealData);
            this.axKHOpenAPI1.OnReceiveChejanData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(this.axKHOpenAPI1_OnReceiveChejanData);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(561, 90);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(978, 788);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox5);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.grp2);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 90);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(561, 788);
            this.panel4.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.status);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 655);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(561, 133);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "로그";
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Black;
            this.status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.status.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.status.ForeColor = System.Drawing.Color.Lime;
            this.status.FormattingEnabled = true;
            this.status.ItemHeight = 16;
            this.status.Location = new System.Drawing.Point(2, 20);
            this.status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(557, 111);
            this.status.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 653);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitter1.Size = new System.Drawing.Size(561, 2);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(561, 145);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "검색";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(559, 90);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 788);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // seq
            // 
            this.seq.HeaderText = "순번";
            this.seq.MinimumWidth = 8;
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            this.seq.Width = 60;
            // 
            // jongmok_nm
            // 
            this.jongmok_nm.HeaderText = "종목명";
            this.jongmok_nm.MinimumWidth = 6;
            this.jongmok_nm.Name = "jongmok_nm";
            this.jongmok_nm.ReadOnly = true;
            this.jongmok_nm.Width = 80;
            // 
            // amount
            // 
            this.amount.HeaderText = "보유수량";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 80;
            // 
            // average_price
            // 
            this.average_price.HeaderText = "평균단가";
            this.average_price.MinimumWidth = 6;
            this.average_price.Name = "average_price";
            this.average_price.ReadOnly = true;
            this.average_price.Width = 80;
            // 
            // buy_price
            // 
            this.buy_price.HeaderText = "매입금액";
            this.buy_price.MinimumWidth = 6;
            this.buy_price.Name = "buy_price";
            this.buy_price.ReadOnly = true;
            this.buy_price.Width = 80;
            // 
            // profit
            // 
            this.profit.HeaderText = "평가금액";
            this.profit.MinimumWidth = 6;
            this.profit.Name = "profit";
            this.profit.ReadOnly = true;
            this.profit.Width = 80;
            // 
            // profit_amount
            // 
            this.profit_amount.HeaderText = "손익금액";
            this.profit_amount.MinimumWidth = 6;
            this.profit_amount.Name = "profit_amount";
            this.profit_amount.ReadOnly = true;
            this.profit_amount.Width = 80;
            // 
            // profit_loss_rate
            // 
            this.profit_loss_rate.HeaderText = "손익율";
            this.profit_loss_rate.MinimumWidth = 6;
            this.profit_loss_rate.Name = "profit_loss_rate";
            this.profit_loss_rate.ReadOnly = true;
            this.profit_loss_rate.Width = 80;
            // 
            // today_buy
            // 
            this.today_buy.HeaderText = "금일매수수량";
            this.today_buy.MinimumWidth = 6;
            this.today_buy.Name = "today_buy";
            this.today_buy.ReadOnly = true;
            this.today_buy.Width = 80;
            // 
            // today_sell
            // 
            this.today_sell.HeaderText = "금일매도수량";
            this.today_sell.MinimumWidth = 6;
            this.today_sell.Name = "today_sell";
            this.today_sell.ReadOnly = true;
            this.today_sell.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1539, 878);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "주식";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp2.ResumeLayout(false);
            this.grp2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buyAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellAmount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAcnum1;
        private System.Windows.Forms.Label lblAcnum1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grp2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox price_text;
        private System.Windows.Forms.Label lblCurPrice;
        private System.Windows.Forms.Label lblEventname;
        private System.Windows.Forms.NumericUpDown buyAmount;
        private System.Windows.Forms.NumericUpDown sellAmount;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.TextBox code_text;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label stock_name_label;
        private System.Windows.Forms.Label stock_name;
        private System.Windows.Forms.Label start_price_label;
        private System.Windows.Forms.Label start_price;
        private System.Windows.Forms.Label total_amount_label;
        private System.Windows.Forms.Label current_price_label;
        private System.Windows.Forms.Label current_price;
        private System.Windows.Forms.Label high_price_label;
        private System.Windows.Forms.Label year_high_label;
        private System.Windows.Forms.Label difference_label;
        private System.Windows.Forms.Label difference;
        private System.Windows.Forms.Label low_price_label;
        private System.Windows.Forms.Label low_price;
        private System.Windows.Forms.Label year_low_label;
        private System.Windows.Forms.Label total_amount;
        private System.Windows.Forms.Label year_high;
        private System.Windows.Forms.Label year_low;
        private System.Windows.Forms.ComboBox stockList;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
        private System.Windows.Forms.Label high_price;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnAutoEnd;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListBox status;
        private System.Windows.Forms.TextBox stock_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn average_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit_loss_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn today_buy;
        private System.Windows.Forms.DataGridViewTextBoxColumn today_sell;
    }
}

