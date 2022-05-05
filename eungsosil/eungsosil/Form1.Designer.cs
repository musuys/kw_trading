
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAcnum1 = new System.Windows.Forms.ComboBox();
            this.lblAcnum1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblCurPrice = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblEventname = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.cmbAcnum2 = new System.Windows.Forms.ComboBox();
            this.lblAcnum2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.체크 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grp2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAcnum1);
            this.groupBox1.Controls.Add(this.lblAcnum1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1539, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // cmbAcnum1
            // 
            this.cmbAcnum1.FormattingEnabled = true;
            this.cmbAcnum1.Location = new System.Drawing.Point(529, 24);
            this.cmbAcnum1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbAcnum1.Name = "cmbAcnum1";
            this.cmbAcnum1.Size = new System.Drawing.Size(288, 23);
            this.cmbAcnum1.TabIndex = 3;
            // 
            // lblAcnum1
            // 
            this.lblAcnum1.AutoSize = true;
            this.lblAcnum1.Location = new System.Drawing.Point(455, 27);
            this.lblAcnum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcnum1.Name = "lblAcnum1";
            this.lblAcnum1.Size = new System.Drawing.Size(77, 15);
            this.lblAcnum1.TabIndex = 2;
            this.lblAcnum1.Text = "계좌번호 :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(315, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 25);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(225, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "사용자이름 :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(73, 22);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(129, 25);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 27);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(62, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "아이디 :";
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.panel2);
            this.grp2.Controls.Add(this.splitter1);
            this.grp2.Controls.Add(this.panel1);
            this.grp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp2.Location = new System.Drawing.Point(0, 90);
            this.grp2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.grp2.Size = new System.Drawing.Size(694, 789);
            this.grp2.TabIndex = 3;
            this.grp2.TabStop = false;
            this.grp2.Text = "거래종목";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 129);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 652);
            this.panel2.TabIndex = 7;
            // 
            // dgvList
            // 
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.체크});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 62;
            this.dgvList.RowTemplate.Height = 30;
            this.dgvList.Size = new System.Drawing.Size(678, 652);
            this.dgvList.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(8, 127);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(678, 2);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 101);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(425, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cmbSearch
            // 
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "종목코드",
            "종목이름"});
            this.cmbSearch.Location = new System.Drawing.Point(95, 17);
            this.cmbSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(120, 23);
            this.cmbSearch.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(219, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 25);
            this.txtSearch.TabIndex = 4;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(17, 19);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "종목검색 :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSell);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.lblCurPrice);
            this.groupBox2.Controls.Add(this.btnBuy);
            this.groupBox2.Controls.Add(this.lblEventname);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.lblBuyPrice);
            this.groupBox2.Controls.Add(this.lblNum);
            this.groupBox2.Controls.Add(this.lblSelect);
            this.groupBox2.Controls.Add(this.lblCode);
            this.groupBox2.Controls.Add(this.cmbAcnum2);
            this.groupBox2.Controls.Add(this.lblAcnum2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(694, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(845, 187);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "매매";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(744, 67);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(97, 92);
            this.btnSell.TabIndex = 0;
            this.btnSell.Text = "매도";
            this.btnSell.UseVisualStyleBackColor = true;
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
            this.comboBox3.Location = new System.Drawing.Point(409, 67);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(184, 23);
            this.comboBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(107, 135);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(184, 25);
            this.textBox5.TabIndex = 0;
            // 
            // lblCurPrice
            // 
            this.lblCurPrice.AutoSize = true;
            this.lblCurPrice.Location = new System.Drawing.Point(29, 138);
            this.lblCurPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurPrice.Name = "lblCurPrice";
            this.lblCurPrice.Size = new System.Drawing.Size(77, 15);
            this.lblCurPrice.TabIndex = 12;
            this.lblCurPrice.Text = "시장가격 :";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(634, 67);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(97, 92);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "매수";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // lblEventname
            // 
            this.lblEventname.AutoSize = true;
            this.lblEventname.Location = new System.Drawing.Point(29, 104);
            this.lblEventname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventname.Name = "lblEventname";
            this.lblEventname.Size = new System.Drawing.Size(77, 15);
            this.lblEventname.TabIndex = 10;
            this.lblEventname.Text = "종목이름 :";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(408, 102);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(183, 25);
            this.numericUpDown2.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(409, 136);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(183, 25);
            this.numericUpDown1.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(107, 101);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(184, 25);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(107, 67);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(184, 25);
            this.textBox3.TabIndex = 6;
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(330, 139);
            this.lblBuyPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(77, 15);
            this.lblBuyPrice.TabIndex = 5;
            this.lblBuyPrice.Text = "매수가격 :";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(330, 105);
            this.lblNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(77, 15);
            this.lblNum.TabIndex = 4;
            this.lblNum.Text = "매수수량 :";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(330, 70);
            this.lblSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(67, 15);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "거래구분";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(29, 70);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(77, 15);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "종목코드 :";
            // 
            // cmbAcnum2
            // 
            this.cmbAcnum2.FormattingEnabled = true;
            this.cmbAcnum2.Location = new System.Drawing.Point(107, 32);
            this.cmbAcnum2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbAcnum2.Name = "cmbAcnum2";
            this.cmbAcnum2.Size = new System.Drawing.Size(288, 23);
            this.cmbAcnum2.TabIndex = 1;
            // 
            // lblAcnum2
            // 
            this.lblAcnum2.AutoSize = true;
            this.lblAcnum2.Location = new System.Drawing.Point(29, 35);
            this.lblAcnum2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcnum2.Name = "lblAcnum2";
            this.lblAcnum2.Size = new System.Drawing.Size(77, 15);
            this.lblAcnum2.TabIndex = 0;
            this.lblAcnum2.Text = "계좌번호 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(694, 277);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(845, 602);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "차트";
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
            // 체크
            // 
            this.체크.HeaderText = "check";
            this.체크.MinimumWidth = 6;
            this.체크.Name = "체크";
            this.체크.Width = 60;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(1952, 0);
            this.axKHOpenAPI1.Margin = new System.Windows.Forms.Padding(2);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(150, 75);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "삽입";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "수정";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(331, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "삭제";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 879);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "주식";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblCurPrice;
        private System.Windows.Forms.Button btnBuy;
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
        private System.Windows.Forms.ComboBox cmbAcnum2;
        private System.Windows.Forms.Label lblAcnum2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSell;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn 체크;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

