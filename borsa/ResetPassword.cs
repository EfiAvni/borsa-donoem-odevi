using borsa.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsa
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {

            string enteredCode = tBoxCheck.Text;
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
                    MessageBox.Show("Parolanız Başarıyla Değiştirildi!");
                    Application.Restart();
                    Environment.Exit(0);
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

        private void buttonCode_Click(object sender, EventArgs e)
        {
            try
            {
                SqlOperations.CheckConnection();

                // 6 haneli rastgele bir doğrulama kodu oluştur
                string verificationCode = new Random().Next(100000, 999999).ToString();

                SqlCommand RegCommand = new SqlCommand("UPDATE users SET password=@password,verification_code=@verification_code where mail=@mail", SqlOperations.connection);

                string hashedPassword = Sha256Converter.ComputeSha256Hash(tBoxPassword.Text);

                RegCommand.Parameters.AddWithValue("@mail", tBoxMail.Text);
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

        AccountPage accountPage = Application.OpenForms["AccountPage"] as AccountPage;

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            if (accountPage != null)
            {
                // accountPage.MailAddress'e tBoxMail'e veri atıyoruz
                tBoxMail.Text = accountPage.MailAddress;

                // Mail adresini sadece okunabilir yapıyoruz
                tBoxMail.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("AccountPage formu açık değil.");
            }
        }
    }
}
