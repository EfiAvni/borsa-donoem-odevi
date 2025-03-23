namespace borsa
{
    partial class AnaSayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonAssets = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonGraphics = new System.Windows.Forms.Button();
            this.buttonNews = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonConverter = new System.Windows.Forms.Button();
            this.labelMail = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonLogin.Location = new System.Drawing.Point(793, 31);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(90, 32);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Giriş Yap";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAssets
            // 
            this.buttonAssets.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonAssets.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonAssets.Location = new System.Drawing.Point(481, 12);
            this.buttonAssets.Name = "buttonAssets";
            this.buttonAssets.Size = new System.Drawing.Size(150, 50);
            this.buttonAssets.TabIndex = 1;
            this.buttonAssets.Text = "Varlıklarım";
            this.buttonAssets.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 370);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Döviz Verileri";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(805, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 370);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Altın Verileri";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(194, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 370);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BIST Verileri";
            // 
            // buttonGraphics
            // 
            this.buttonGraphics.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonGraphics.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonGraphics.Location = new System.Drawing.Point(325, 13);
            this.buttonGraphics.Name = "buttonGraphics";
            this.buttonGraphics.Size = new System.Drawing.Size(150, 49);
            this.buttonGraphics.TabIndex = 5;
            this.buttonGraphics.Text = "Canlı Grafikler";
            this.buttonGraphics.UseVisualStyleBackColor = false;
            this.buttonGraphics.Click += new System.EventHandler(this.buttonGraphics_Click);
            // 
            // buttonNews
            // 
            this.buttonNews.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonNews.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonNews.Location = new System.Drawing.Point(169, 12);
            this.buttonNews.Name = "buttonNews";
            this.buttonNews.Size = new System.Drawing.Size(150, 50);
            this.buttonNews.TabIndex = 6;
            this.buttonNews.Text = "Haberler";
            this.buttonNews.UseVisualStyleBackColor = false;
            this.buttonNews.Click += new System.EventHandler(this.buttonNews_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonAccount.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonAccount.Location = new System.Drawing.Point(13, 12);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(150, 50);
            this.buttonAccount.TabIndex = 7;
            this.buttonAccount.Text = "Hesabım";
            this.buttonAccount.UseVisualStyleBackColor = false;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonConverter
            // 
            this.buttonConverter.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonConverter.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonConverter.Location = new System.Drawing.Point(637, 13);
            this.buttonConverter.Name = "buttonConverter";
            this.buttonConverter.Size = new System.Drawing.Size(150, 50);
            this.buttonConverter.TabIndex = 8;
            this.buttonConverter.Text = "Kur Çevirici";
            this.buttonConverter.UseVisualStyleBackColor = false;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(794, 12);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(101, 16);
            this.labelMail.TabIndex = 9;
            this.labelMail.Text = "Giriş Yapılmadı!";
            this.labelMail.Click += new System.EventHandler(this.labelMail_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonLogOut.Location = new System.Drawing.Point(887, 31);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(90, 32);
            this.buttonLogOut.TabIndex = 10;
            this.buttonLogOut.Text = "Çıkış Yap";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(993, 447);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.buttonConverter);
            this.Controls.Add(this.buttonAccount);
            this.Controls.Add(this.buttonNews);
            this.Controls.Add(this.buttonGraphics);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAssets);
            this.Controls.Add(this.buttonLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaSayfa";
            this.Text = "Borsa Uygulaması";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonAssets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonGraphics;
        private System.Windows.Forms.Button buttonNews;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonConverter;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button button1;
    }
}