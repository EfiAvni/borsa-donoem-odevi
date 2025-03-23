using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsa.Classes
{
    public class UserRepository
    {
        public User GetUserByMail(string mail)
        {
            SqlOperations.CheckConnection(); // Bağlantıyı kontrol et

            string query = "SELECT name, surname, mail, phone FROM users WHERE mail = @mail";
            using (SqlCommand command = new SqlCommand(query, SqlOperations.connection))
            {
                // Parametreyi ekle
                command.Parameters.AddWithValue("@mail", mail);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Mail = reader["mail"].ToString(),
                            Phone = reader["phone"].ToString()
                        };
                    }
                }
            }

            return null; // Kullanıcı bulunamazsa null döner
        }
    }


    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }

}
