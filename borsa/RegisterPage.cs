using borsa.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace borsa
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlOperations.CheckConnection();

                // 6 haneli rastgele bir doğrulama kodu oluştur
                string verificationCode = new Random().Next(100000, 999999).ToString();

                SqlCommand RegCommand = new SqlCommand("insert into users (name, surname, mail, phone, password, verification_code, is_verified) values (@name, @surname, @mail, @phone, @password, @verification_code, 0)", SqlOperations.connection);

                string hashedPassword = Sha256Converter.ComputeSha256Hash(tBoxPassword.Text);

                RegCommand.Parameters.AddWithValue("@name", tBoxName.Text);
                RegCommand.Parameters.AddWithValue("@surname", tBoxSurname.Text);
                RegCommand.Parameters.AddWithValue("@mail", tBoxMail.Text);
                RegCommand.Parameters.AddWithValue("@phone", tBoxPhone.Text);
                RegCommand.Parameters.AddWithValue("@password", hashedPassword);
                RegCommand.Parameters.AddWithValue("@verification_code", verificationCode);

                int result = RegCommand.ExecuteNonQuery();

                if (result > 0)
                {
                    SendVerificationMail(tBoxMail.Text, verificationCode); // Mail gönder
                    MessageBox.Show("Doğrulama kodu gönderildi. Lütfen mailinizi kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendVerificationMail(string email, string verificationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sysx64.shell@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Doğrulama Kodu";
                mail.Body = $"Merhaba,\n\nDoğrulama kodunuz: {verificationCode}\n\nİyi günler dileriz.";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("sysx64.shell@gmail.com", "dhdv wgjr cgfx xzis");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderimi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string enteredCode = tBoxVerify.Text;
            string mail = tBoxMail.Text;

            // Girdi kontrolü
            if (string.IsNullOrEmpty(enteredCode) || string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            SqlCommand command = new SqlCommand("SELECT verification_code FROM users WHERE mail = @mail", SqlOperations.connection);
            SqlOperations.CheckConnection();
            command.Parameters.AddWithValue("@mail", mail);

            string verificationCode = (string)command.ExecuteScalar();

            if (verificationCode == enteredCode)
            {
                // Güncelleme komutu
                SqlCommand cmdUpdate = new SqlCommand("UPDATE users SET is_verified = 1 WHERE mail = @mail", SqlOperations.connection);
                cmdUpdate.Parameters.AddWithValue("@mail", mail); // Parametreyi eklemeyi unutma!

                int rowsAffected = cmdUpdate.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Hesap Doğrulandı! Giriş Yapabilirsiniz.");
                    LoginPage lp = new LoginPage();
                    lp.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hesap doğrulanırken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Doğrulama Kodu Hatalı!");
            }
        }
    }
}
