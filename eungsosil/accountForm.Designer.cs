
namespace eungsosil
{
    partial class accountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accountForm));
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.combox1 = new System.Windows.Forms.ComboBox();
            this.rate_label = new System.Windows.Forms.Label();
            this.rate_text = new System.Windows.Forms.TextBox();
            this.money_label = new System.Windows.Forms.Label();
            this.money_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(3, 303);
            this.axKHOpenAPI1.Margin = new System.Windows.Forms.Padding(2);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(79, 24);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "계좌번호";
            this.label1.UseWaitCursor = true;
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(13, 232);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAccount.Size = new System.Drawing.Size(194, 25);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "조회";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.UseWaitCursor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "전체매입금액";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "전체평가금액";
            this.label4.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "전체손해금액";
            this.label5.UseWaitCursor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 90);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(112, 21);
            this.textBox3.TabIndex = 9;
            this.textBox3.UseWaitCursor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 121);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(112, 21);
            this.textBox4.TabIndex = 10;
            this.textBox4.UseWaitCursor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(93, 150);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(112, 21);
            this.textBox5.TabIndex = 11;
            this.textBox5.UseWaitCursor = true;
            // 
            // combox1
            // 
            this.combox1.FormattingEnabled = true;
            this.combox1.Location = new System.Drawing.Point(93, 26);
            this.combox1.Margin = new System.Windows.Forms.Padding(2);
            this.combox1.Name = "combox1";
            this.combox1.Size = new System.Drawing.Size(112, 20);
            this.combox1.TabIndex = 12;
            this.combox1.UseWaitCursor = true;
            // 
            // rate_label
            // 
            this.rate_label.AutoSize = true;
            this.rate_label.Location = new System.Drawing.Point(11, 185);
            this.rate_label.Name = "rate_label";
            this.rate_label.Size = new System.Drawing.Size(73, 12);
            this.rate_label.TabIndex = 13;
            this.rate_label.Text = "총수익율(%)";
            this.rate_label.UseWaitCursor = true;
            // 
            // rate_text
            // 
            this.rate_text.Location = new System.Drawing.Point(93, 181);
            this.rate_text.Name = "rate_text";
            this.rate_text.ReadOnly = true;
            this.rate_text.Size = new System.Drawing.Size(112, 21);
            this.rate_text.TabIndex = 14;
            this.rate_text.UseWaitCursor = true;
            // 
            // money_label
            // 
            this.money_label.AutoSize = true;
            this.money_label.Location = new System.Drawing.Point(26, 63);
            this.money_label.Name = "money_label";
            this.money_label.Size = new System.Drawing.Size(41, 12);
            this.money_label.TabIndex = 15;
            this.money_label.Text = "예수금";
            this.money_label.UseWaitCursor = true;
            // 
            // money_text
            // 
            this.money_text.Location = new System.Drawing.Point(93, 59);
            this.money_text.Name = "money_text";
            this.money_text.ReadOnly = true;
            this.money_text.Size = new System.Drawing.Size(112, 21);
            this.money_text.TabIndex = 16;
            this.money_text.UseWaitCursor = true;
            // 
            // accountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 273);
            this.Controls.Add(this.money_text);
            this.Controls.Add(this.money_label);
            this.Controls.Add(this.rate_text);
            this.Controls.Add(this.rate_label);
            this.Controls.Add(this.combox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "accountForm";
            this.Text = "acccountDlg";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox combox1;
        private System.Windows.Forms.Label rate_label;
        private System.Windows.Forms.TextBox rate_text;
        private System.Windows.Forms.Label money_label;
        private System.Windows.Forms.TextBox money_text;
    }
}