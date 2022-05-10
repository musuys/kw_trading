
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cut_loss_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_trd_yn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sell_trd_yn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.stockList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.검색button = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblCurPrice = new System.Windows.Forms.Label();
            this.lblEventname = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grp2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
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
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1502, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(55, 20);
            this.mnuLogin.Text = "로그인";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1502, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(738, 15);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(85, 26);
            this.btnAccount.TabIndex = 7;
            this.btnAccount.Text = "계좌정보";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // cmbAcnum1
            // 
            this.cmbAcnum1.FormattingEnabled = true;
            this.cmbAcnum1.Location = new System.Drawing.Point(463, 18);
            this.cmbAcnum1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAcnum1.Name = "cmbAcnum1";
            this.cmbAcnum1.Size = new System.Drawing.Size(252, 20);
            this.cmbAcnum1.TabIndex = 3;
            this.cmbAcnum1.SelectedIndexChanged += new System.EventHandler(this.cmbAcnum1_SelectedIndexChanged_1);
            // 
            // lblAcnum1
            // 
            this.lblAcnum1.AutoSize = true;
            this.lblAcnum1.Location = new System.Drawing.Point(398, 22);
            this.lblAcnum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcnum1.Name = "lblAcnum1";
            this.lblAcnum1.Size = new System.Drawing.Size(61, 12);
            this.lblAcnum1.TabIndex = 2;
            this.lblAcnum1.Text = "계좌번호 :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(276, 18);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(197, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(73, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "사용자이름 :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(64, 18);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(113, 21);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(8, 22);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(49, 12);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "아이디 :";
            // 
            // btnAutoEnd
            // 
            this.btnAutoEnd.Location = new System.Drawing.Point(611, 36);
            this.btnAutoEnd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutoEnd.Name = "btnAutoEnd";
            this.btnAutoEnd.Size = new System.Drawing.Size(79, 74);
            this.btnAutoEnd.TabIndex = 6;
            this.btnAutoEnd.Text = "자동매매\r\n종료";
            this.btnAutoEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAutoEnd.UseVisualStyleBackColor = false;
            this.btnAutoEnd.Click += new System.EventHandler(this.btnAutoEnd_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(518, 36);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(79, 74);
            this.btnAuto.TabIndex = 5;
            this.btnAuto.Text = "자동매매\r\n시작";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.statusStrip1);
            this.grp2.Controls.Add(this.panel2);
            this.grp2.Controls.Add(this.splitter1);
            this.grp2.Controls.Add(this.panel1);
            this.grp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp2.Location = new System.Drawing.Point(0, 74);
            this.grp2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.grp2.Size = new System.Drawing.Size(677, 629);
            this.grp2.TabIndex = 3;
            this.grp2.TabStop = false;
            this.grp2.Text = "거래종목";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(7, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(663, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel1.Text = "주식프로그램접속중....";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 104);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 519);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.priority,
            this.jongmok_cd,
            this.jongmok_nm,
            this.buy_amt,
            this.buy_price,
            this.target_price,
            this.cut_loss_price,
            this.buy_trd_yn,
            this.sell_trd_yn,
            this.check});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(663, 519);
            this.dataGridView1.TabIndex = 4;
            // 
            // seq
            // 
            this.seq.Frozen = true;
            this.seq.HeaderText = "순번";
            this.seq.MinimumWidth = 8;
            this.seq.Name = "seq";
            this.seq.Width = 60;
            // 
            // priority
            // 
            this.priority.HeaderText = "우선순위";
            this.priority.MinimumWidth = 6;
            this.priority.Name = "priority";
            this.priority.Width = 80;
            // 
            // jongmok_cd
            // 
            this.jongmok_cd.HeaderText = "종목코드";
            this.jongmok_cd.MinimumWidth = 6;
            this.jongmok_cd.Name = "jongmok_cd";
            this.jongmok_cd.Width = 80;
            // 
            // jongmok_nm
            // 
            this.jongmok_nm.HeaderText = "종목명";
            this.jongmok_nm.MinimumWidth = 6;
            this.jongmok_nm.Name = "jongmok_nm";
            this.jongmok_nm.Width = 80;
            // 
            // buy_amt
            // 
            this.buy_amt.HeaderText = "매수금액";
            this.buy_amt.MinimumWidth = 6;
            this.buy_amt.Name = "buy_amt";
            this.buy_amt.Width = 80;
            // 
            // buy_price
            // 
            this.buy_price.HeaderText = "매수가";
            this.buy_price.MinimumWidth = 6;
            this.buy_price.Name = "buy_price";
            this.buy_price.Width = 70;
            // 
            // target_price
            // 
            this.target_price.HeaderText = "목표가";
            this.target_price.MinimumWidth = 6;
            this.target_price.Name = "target_price";
            this.target_price.Width = 70;
            // 
            // cut_loss_price
            // 
            this.cut_loss_price.HeaderText = "손절가";
            this.cut_loss_price.MinimumWidth = 6;
            this.cut_loss_price.Name = "cut_loss_price";
            this.cut_loss_price.Width = 70;
            // 
            // buy_trd_yn
            // 
            this.buy_trd_yn.HeaderText = "매수여부";
            this.buy_trd_yn.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.buy_trd_yn.MinimumWidth = 6;
            this.buy_trd_yn.Name = "buy_trd_yn";
            this.buy_trd_yn.Width = 80;
            // 
            // sell_trd_yn
            // 
            this.sell_trd_yn.HeaderText = "매도여부";
            this.sell_trd_yn.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.sell_trd_yn.MinimumWidth = 6;
            this.sell_trd_yn.Name = "sell_trd_yn";
            this.sell_trd_yn.Width = 80;
            // 
            // check
            // 
            this.check.HeaderText = "체크";
            this.check.MinimumWidth = 6;
            this.check.Name = "check";
            this.check.Width = 60;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(7, 102);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(663, 2);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.stockList);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.검색button);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(7, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 82);
            this.panel1.TabIndex = 5;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(515, 12);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(79, 24);
            this.searchBtn.TabIndex = 20;
            this.searchBtn.Text = "차트조회";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "종목코드 검색 :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(290, 46);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 18);
            this.button4.TabIndex = 9;
            this.button4.Text = "삭제";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 46);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 18);
            this.button3.TabIndex = 8;
            this.button3.Text = "수정";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 46);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 18);
            this.button2.TabIndex = 7;
            this.button2.Text = "삽입";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stockList
            // 
            this.stockList.FormattingEnabled = true;
            this.stockList.Location = new System.Drawing.Point(431, 14);
            this.stockList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(79, 20);
            this.stockList.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 18);
            this.button1.TabIndex = 6;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 검색button
            // 
            this.검색button.Location = new System.Drawing.Point(226, 12);
            this.검색button.Margin = new System.Windows.Forms.Padding(2);
            this.검색button.Name = "검색button";
            this.검색button.Size = new System.Drawing.Size(70, 20);
            this.검색button.TabIndex = 4;
            this.검색button.Text = "차트조회";
            this.검색button.UseVisualStyleBackColor = true;
            this.검색button.Click += new System.EventHandler(this.stockSearch);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(96, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(126, 21);
            this.txtSearch.TabIndex = 4;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 14);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(73, 12);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "종목명검색 :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.btnAutoEnd);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.btnAuto);
            this.groupBox2.Controls.Add(this.lblCurPrice);
            this.groupBox2.Controls.Add(this.lblEventname);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.lblBuyPrice);
            this.groupBox2.Controls.Add(this.lblNum);
            this.groupBox2.Controls.Add(this.lblSelect);
            this.groupBox2.Controls.Add(this.lblCode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(677, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(825, 134);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매매";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "지정가",
            "시장가",
            "조건부지정가",
            "최유리지정가",
            "최우선지정가",
            "장전 시간외",
            "장후 시간외"});
            this.comboBox3.Location = new System.Drawing.Point(334, 36);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(162, 20);
            this.comboBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(88, 90);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(162, 21);
            this.textBox5.TabIndex = 0;
            // 
            // lblCurPrice
            // 
            this.lblCurPrice.AutoSize = true;
            this.lblCurPrice.Location = new System.Drawing.Point(19, 92);
            this.lblCurPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurPrice.Name = "lblCurPrice";
            this.lblCurPrice.Size = new System.Drawing.Size(61, 12);
            this.lblCurPrice.TabIndex = 12;
            this.lblCurPrice.Text = "시장가격 :";
            // 
            // lblEventname
            // 
            this.lblEventname.AutoSize = true;
            this.lblEventname.Location = new System.Drawing.Point(19, 65);
            this.lblEventname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventname.Name = "lblEventname";
            this.lblEventname.Size = new System.Drawing.Size(61, 12);
            this.lblEventname.TabIndex = 10;
            this.lblEventname.Text = "종목이름 :";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(334, 64);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(160, 21);
            this.numericUpDown2.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(334, 91);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(160, 21);
            this.numericUpDown1.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(88, 63);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(162, 21);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(88, 36);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(162, 21);
            this.textBox3.TabIndex = 6;
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(266, 93);
            this.lblBuyPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(61, 12);
            this.lblBuyPrice.TabIndex = 5;
            this.lblBuyPrice.Text = "매수가격 :";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(266, 66);
            this.lblNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(61, 12);
            this.lblNum.TabIndex = 4;
            this.lblNum.Text = "매수수량 :";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(266, 38);
            this.lblSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(53, 12);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "거래구분";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(19, 38);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(61, 12);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "종목코드 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stockChart);
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(677, 208);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(825, 495);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "차트";
            // 
            // stockChart
            // 
            chartArea1.AxisX.IsReversed = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(5, 122);
            this.stockChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockChart.Name = "stockChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series1.Legend = "Legend1";
            series1.Name = "chart_data";
            series1.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series1);
            this.stockChart.Size = new System.Drawing.Size(727, 369);
            this.stockChart.TabIndex = 19;
            this.stockChart.Text = "chart1";
            this.stockChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.stockChart_AxisViewChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 100);
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
            this.stock_name_label.Size = new System.Drawing.Size(109, 33);
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
            this.stock_name.Location = new System.Drawing.Point(118, 0);
            this.stock_name.Name = "stock_name";
            this.stock_name.Size = new System.Drawing.Size(153, 33);
            this.stock_name.TabIndex = 1;
            this.stock_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_price_label
            // 
            this.start_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_price_label.AutoSize = true;
            this.start_price_label.Location = new System.Drawing.Point(277, 0);
            this.start_price_label.Name = "start_price_label";
            this.start_price_label.Size = new System.Drawing.Size(71, 33);
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
            this.start_price.Location = new System.Drawing.Point(354, 0);
            this.start_price.Name = "start_price";
            this.start_price.Size = new System.Drawing.Size(140, 33);
            this.start_price.TabIndex = 3;
            this.start_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_amount_label
            // 
            this.total_amount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total_amount_label.AutoSize = true;
            this.total_amount_label.Location = new System.Drawing.Point(500, 0);
            this.total_amount_label.Name = "total_amount_label";
            this.total_amount_label.Size = new System.Drawing.Size(75, 33);
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
            this.current_price_label.Location = new System.Drawing.Point(3, 33);
            this.current_price_label.Name = "current_price_label";
            this.current_price_label.Size = new System.Drawing.Size(109, 33);
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
            this.current_price.Location = new System.Drawing.Point(118, 33);
            this.current_price.Name = "current_price";
            this.current_price.Size = new System.Drawing.Size(153, 33);
            this.current_price.TabIndex = 7;
            this.current_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // high_price_label
            // 
            this.high_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.high_price_label.AutoSize = true;
            this.high_price_label.Location = new System.Drawing.Point(277, 33);
            this.high_price_label.Name = "high_price_label";
            this.high_price_label.Size = new System.Drawing.Size(71, 33);
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
            this.high_price.Location = new System.Drawing.Point(354, 33);
            this.high_price.Name = "high_price";
            this.high_price.Size = new System.Drawing.Size(140, 33);
            this.high_price.TabIndex = 9;
            this.high_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.high_price.Click += new System.EventHandler(this.label10_Click);
            // 
            // year_high_label
            // 
            this.year_high_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high_label.AutoSize = true;
            this.year_high_label.Location = new System.Drawing.Point(500, 33);
            this.year_high_label.Name = "year_high_label";
            this.year_high_label.Size = new System.Drawing.Size(75, 33);
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
            this.difference_label.Location = new System.Drawing.Point(3, 66);
            this.difference_label.Name = "difference_label";
            this.difference_label.Size = new System.Drawing.Size(109, 34);
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
            this.difference.Location = new System.Drawing.Point(118, 66);
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(153, 34);
            this.difference.TabIndex = 13;
            this.difference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // low_price_label
            // 
            this.low_price_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.low_price_label.AutoSize = true;
            this.low_price_label.Location = new System.Drawing.Point(277, 66);
            this.low_price_label.Name = "low_price_label";
            this.low_price_label.Size = new System.Drawing.Size(71, 34);
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
            this.low_price.Location = new System.Drawing.Point(354, 66);
            this.low_price.Name = "low_price";
            this.low_price.Size = new System.Drawing.Size(140, 34);
            this.low_price.TabIndex = 15;
            this.low_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low_label
            // 
            this.year_low_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low_label.AutoSize = true;
            this.year_low_label.Location = new System.Drawing.Point(500, 66);
            this.year_low_label.Name = "year_low_label";
            this.year_low_label.Size = new System.Drawing.Size(75, 34);
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
            this.total_amount.Location = new System.Drawing.Point(581, 0);
            this.total_amount.Name = "total_amount";
            this.total_amount.Size = new System.Drawing.Size(143, 33);
            this.total_amount.TabIndex = 17;
            this.total_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_high
            // 
            this.year_high.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_high.AutoSize = true;
            this.year_high.Location = new System.Drawing.Point(581, 33);
            this.year_high.Name = "year_high";
            this.year_high.Size = new System.Drawing.Size(143, 33);
            this.year_high.TabIndex = 18;
            this.year_high.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // year_low
            // 
            this.year_low.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_low.AutoSize = true;
            this.year_low.Location = new System.Drawing.Point(581, 66);
            this.year_low.Name = "year_low";
            this.year_low.Size = new System.Drawing.Size(143, 34);
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
            this.axKHOpenAPI1.Size = new System.Drawing.Size(225, 112);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI1_OnReceiveTrData);
            this.axKHOpenAPI1.OnReceiveRealData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEventHandler(this.axKHOpenAPI1_OnReceiveRealData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 703);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "주식";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp2.ResumeLayout(false);
            this.grp2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button 검색button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblCurPrice;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label lblEventname;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cut_loss_price;
        private System.Windows.Forms.DataGridViewComboBoxColumn buy_trd_yn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sell_trd_yn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
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
    }
}

