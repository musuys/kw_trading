
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
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
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
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.btnSell = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grp2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(1952, 0);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(150, 75);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(2102, 33);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(82, 29);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2102, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // cmbAcnum1
            // 
            this.cmbAcnum1.FormattingEnabled = true;
            this.cmbAcnum1.Location = new System.Drawing.Point(661, 29);
            this.cmbAcnum1.Name = "cmbAcnum1";
            this.cmbAcnum1.Size = new System.Drawing.Size(359, 26);
            this.cmbAcnum1.TabIndex = 3;
            // 
            // lblAcnum1
            // 
            this.lblAcnum1.AutoSize = true;
            this.lblAcnum1.Location = new System.Drawing.Point(569, 33);
            this.lblAcnum1.Name = "lblAcnum1";
            this.lblAcnum1.Size = new System.Drawing.Size(92, 18);
            this.lblAcnum1.TabIndex = 2;
            this.lblAcnum1.Text = "계좌번호 :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(394, 27);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 28);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(281, 33);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "사용자이름 :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(91, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(160, 28);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(11, 33);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "아이디 :";
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.panel2);
            this.grp2.Controls.Add(this.splitter1);
            this.grp2.Controls.Add(this.panel1);
            this.grp2.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp2.Location = new System.Drawing.Point(0, 108);
            this.grp2.Margin = new System.Windows.Forms.Padding(10);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(10);
            this.grp2.Size = new System.Drawing.Size(868, 997);
            this.grp2.TabIndex = 3;
            this.grp2.TabStop = false;
            this.grp2.Text = "거래종목";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 890);
            this.panel2.TabIndex = 7;
            // 
            // dgvList
            // 
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.eventCode,
            this.eventName,
            this.currentPrice,
            this.prevDay,
            this.volume,
            this.upDown});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 62;
            this.dgvList.RowTemplate.Height = 30;
            this.dgvList.Size = new System.Drawing.Size(848, 890);
            this.dgvList.TabIndex = 4;
            // 
            // seq
            // 
            this.seq.Frozen = true;
            this.seq.HeaderText = "번호";
            this.seq.MinimumWidth = 8;
            this.seq.Name = "seq";
            this.seq.Width = 80;
            // 
            // eventCode
            // 
            this.eventCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.eventCode.HeaderText = "종목코드";
            this.eventCode.MinimumWidth = 8;
            this.eventCode.Name = "eventCode";
            // 
            // eventName
            // 
            this.eventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.eventName.HeaderText = "종목이름";
            this.eventName.MinimumWidth = 8;
            this.eventName.Name = "eventName";
            // 
            // currentPrice
            // 
            this.currentPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.currentPrice.HeaderText = "시장가";
            this.currentPrice.MinimumWidth = 8;
            this.currentPrice.Name = "currentPrice";
            // 
            // prevDay
            // 
            this.prevDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prevDay.HeaderText = "전일대비";
            this.prevDay.MinimumWidth = 8;
            this.prevDay.Name = "prevDay";
            // 
            // volume
            // 
            this.volume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volume.HeaderText = "거래량";
            this.volume.MinimumWidth = 8;
            this.volume.Name = "volume";
            // 
            // upDown
            // 
            this.upDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.upDown.HeaderText = "등락율";
            this.upDown.MinimumWidth = 8;
            this.upDown.Name = "upDown";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(10, 94);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(848, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 63);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(531, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
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
            this.cmbSearch.Location = new System.Drawing.Point(119, 20);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(149, 26);
            this.cmbSearch.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(274, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(251, 28);
            this.txtSearch.TabIndex = 4;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(21, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(92, 18);
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
            this.groupBox2.Location = new System.Drawing.Point(868, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1234, 225);
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
            this.comboBox3.Location = new System.Drawing.Point(511, 80);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(229, 26);
            this.comboBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(134, 162);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(229, 28);
            this.textBox5.TabIndex = 0;
            // 
            // lblCurPrice
            // 
            this.lblCurPrice.AutoSize = true;
            this.lblCurPrice.Location = new System.Drawing.Point(36, 166);
            this.lblCurPrice.Name = "lblCurPrice";
            this.lblCurPrice.Size = new System.Drawing.Size(92, 18);
            this.lblCurPrice.TabIndex = 12;
            this.lblCurPrice.Text = "시장가격 :";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(793, 80);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(121, 111);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "매수";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // lblEventname
            // 
            this.lblEventname.AutoSize = true;
            this.lblEventname.Location = new System.Drawing.Point(36, 125);
            this.lblEventname.Name = "lblEventname";
            this.lblEventname.Size = new System.Drawing.Size(92, 18);
            this.lblEventname.TabIndex = 10;
            this.lblEventname.Text = "종목이름 :";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(510, 122);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(229, 28);
            this.numericUpDown2.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(511, 163);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(229, 28);
            this.numericUpDown1.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(134, 121);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(229, 28);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(134, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 28);
            this.textBox3.TabIndex = 6;
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(413, 167);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(92, 18);
            this.lblBuyPrice.TabIndex = 5;
            this.lblBuyPrice.Text = "매수가격 :";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(412, 126);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(92, 18);
            this.lblNum.TabIndex = 4;
            this.lblNum.Text = "매수수량 :";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(412, 84);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(80, 18);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "거래구분";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(36, 84);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(92, 18);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "종목코드 :";
            // 
            // cmbAcnum2
            // 
            this.cmbAcnum2.FormattingEnabled = true;
            this.cmbAcnum2.Location = new System.Drawing.Point(134, 39);
            this.cmbAcnum2.Name = "cmbAcnum2";
            this.cmbAcnum2.Size = new System.Drawing.Size(359, 26);
            this.cmbAcnum2.TabIndex = 1;
            // 
            // lblAcnum2
            // 
            this.lblAcnum2.AutoSize = true;
            this.lblAcnum2.Location = new System.Drawing.Point(36, 42);
            this.lblAcnum2.Name = "lblAcnum2";
            this.lblAcnum2.Size = new System.Drawing.Size(92, 18);
            this.lblAcnum2.TabIndex = 0;
            this.lblAcnum2.Text = "계좌번호 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(868, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1234, 772);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "차트";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(930, 81);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(121, 110);
            this.btnSell.TabIndex = 0;
            this.btnSell.Text = "매도";
            this.btnSell.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2102, 1105);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "주식";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn upDown;
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
    }
}

