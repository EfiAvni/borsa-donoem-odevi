using borsa.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsa
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            RegisterPage rp = new RegisterPage();
            this.Hide();
            rp.Show();
        }

        private bool AuthenticateUser(string mail, string password, out string errorMessage)
        {
            errorMessage = string.Empty;
            SqlCommand loginCommand = new SqlCommand("select * from users where mail=@mail", SqlOperations.connection);

            SqlOperations.CheckConnection();
            loginCommand.Parameters.AddWithValue("@mail", mail);

            string comingPassword = null;

            using (SqlDataReader reader = loginCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    comingPassword = reader["Password"].ToString();
                }
            }

            if (string.IsNullOrEmpty(comingPassword) || !Sha256Converter.VerifyPassword(password, comingPassword))
            {
                errorMessage = "Kullanıcı adı veya şifre yanlış!";
                return false;
            }

            return true;
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxMail.Text) && string.IsNullOrEmpty(tBoxPassword.Text))
            {
                MessageBox.Show("E-Posta ve şifre girin!");
            }
            else
            {
                if (AuthenticateUser(tBoxMail.Text, tBoxPassword.Text, out string errorMessage))
                {
                    AnaSayfa newForm = new AnaSayfa();
                    this.Hide();
                    newForm.Show();
                    newForm.MailAddress = tBoxMail.Text;
                }
                else
                {
                    MessageBox.Show("E-Posta veya şifre yanlış!");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxShow.Checked)
            {
                tBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void tBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBoxMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
