using BorsaUygulamasi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace borsa
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            string mail = labelMail.Text;
            AccountPage ap = new AccountPage(mail);
            ap.Show();
        }

        public void labelMail_Click(object sender, EventArgs e)
        {
            
        }
        public string MailAddress
        {
            get { return labelMail.Text; }
            set { labelMail.Text = value; }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            string text = labelMail.Text;
            if (text=="Giriş Yapılmadı!")
            {
                MessageBox.Show("Giriş Yapmış kullanıcı yok!");
            }
            else
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonNews_Click(object sender, EventArgs e)
        {
            News news = new News();
            news.Show();
            this.Hide();
        }

        private void buttonGraphics_Click(object sender, EventArgs e)
        {
            borsa borsa = new borsa();
            borsa.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
