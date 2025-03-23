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
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace borsa
{
    public partial class AccountPage : Form
    {
        private string userMail;
        private UserRepository userRepository = new UserRepository();
        public AccountPage(string mail)
        {
            InitializeComponent();
            userMail = mail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa mp = new AnaSayfa();
            mp.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public string MailAddress
        {
            get { return tBoxMail.Text; }
        }

        private void AccountPage_Load(object sender, EventArgs e)
        {
            // Kullanıcı bilgilerini mail ile al
            User user = userRepository.GetUserByMail(userMail);

            if (user != null)
            {
                // TextBox'ları doldur
                tBoxName.Text = user.Name;
                tBoxSurname.Text = user.Surname;
                tBoxMail.Text = user.Mail;
                tBoxPhone.Text = user.Phone;
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                this.Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // TextBox kontrolleri için eksiklikleri kontrol et
            if (string.IsNullOrWhiteSpace(tBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(tBoxMail.Text) ||
                string.IsNullOrWhiteSpace(tBoxName.Text) ||
                string.IsNullOrWhiteSpace(tBoxSurname.Text))
            {
                // Eksik veri varsa kullanıcıyı bilgilendir
                MessageBox.Show("Eksik veri girişi yaptınız. Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Fonksiyonu burada bitir
            }

            // Eksik veri yoksa devam et
            try
            {
                SqlCommand CommandRegister = new SqlCommand("UPDATE users SET name = @Name, surname = @Surname, phone = @Phone, mail = @Mail WHERE mail=@Mail", SqlOperations.connection);

                SqlOperations.CheckConnection();

                CommandRegister.Parameters.AddWithValue("@Name", tBoxName.Text);
                CommandRegister.Parameters.AddWithValue("@Surname", tBoxSurname.Text);
                CommandRegister.Parameters.AddWithValue("@Phone", tBoxPhone.Text);
                CommandRegister.Parameters.AddWithValue("@Mail", tBoxMail.Text);

                int result = CommandRegister.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Kullanıcı Başarıyla Güncellendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // TextBox kontrolleri için eksiklikleri kontrol et
                if (string.IsNullOrWhiteSpace(tBoxPhone.Text) ||
                    string.IsNullOrWhiteSpace(tBoxMail.Text) ||
                    string.IsNullOrWhiteSpace(tBoxName.Text) ||
                    string.IsNullOrWhiteSpace(tBoxSurname.Text))
                {
                    MessageBox.Show("Eksik veri girişi yaptınız. Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    SqlCommand CommandRegister = new SqlCommand("DELETE FROM users WHERE mail=@Mail", SqlOperations.connection);
                    SqlOperations.CheckConnection();
                    CommandRegister.Parameters.AddWithValue("@Mail", tBoxMail.Text);

                    int result = CommandRegister.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kullanıcı silme işlemi başarılı!");

                        // Uygulamayı yeniden başlat
                        Application.Restart();
                        Environment.Exit(0); // Eski süreci sonlandır
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı silme işlemi iptal edildi.");
            }
        }

    }
}
