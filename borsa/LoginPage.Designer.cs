namespace borsa
{
    partial class LoginPage
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
            this.tBoxMail = new System.Windows.Forms.TextBox();
            this.tBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonReg = new System.Windows.Forms.Button();
            this.cBoxShow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tBoxMail
            // 
            this.tBoxMail.Location = new System.Drawing.Point(36, 59);
            this.tBoxMail.Name = "tBoxMail";
            this.tBoxMail.Size = new System.Drawing.Size(169, 22);
            this.tBoxMail.TabIndex = 0;
            this.tBoxMail.TextChanged += new System.EventHandler(this.tBoxMail_TextChanged);
            // 
            // tBoxPassword
            // 
            this.tBoxPassword.Location = new System.Drawing.Point(36, 103);
            this.tBoxPassword.Name = "tBoxPassword";
            this.tBoxPassword.Size = new System.Drawing.Size(169, 22);
            this.tBoxPassword.TabIndex = 1;
            this.tBoxPassword.UseSystemPasswordChar = true;
            this.tBoxPassword.TextChanged += new System.EventHandler(this.tBoxPassword_TextChanged);
            // 
            // buttonLog
            // 
            this.buttonLog.Location = new System.Drawing.Point(36, 158);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(169, 39);
            this.buttonLog.TabIndex = 2;
            this.buttonLog.Text = "Giriş Yap";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parola";
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(36, 203);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(169, 39);
            this.buttonReg.TabIndex = 5;
            this.buttonReg.Text = "Kayıt Ol";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // cBoxShow
            // 
            this.cBoxShow.AutoSize = true;
            this.cBoxShow.Location = new System.Drawing.Point(36, 132);
            this.cBoxShow.Name = "cBoxShow";
            this.cBoxShow.Size = new System.Drawing.Size(122, 20);
            this.cBoxShow.TabIndex = 6;
            this.cBoxShow.Text = "Parolayı Göster";
            this.cBoxShow.UseVisualStyleBackColor = true;
            this.cBoxShow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(244, 266);
            this.Controls.Add(this.cBoxShow);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.tBoxPassword);
            this.Controls.Add(this.tBoxMail);
            this.Name = "LoginPage";
            this.Text = "Loginpage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxMail;
        private System.Windows.Forms.TextBox tBoxPassword;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.CheckBox cBoxShow;
    }
}