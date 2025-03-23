using System;
using System.Data;
using System.Data.SqlClient;

namespace borsa.Classes
{
    public class SqlOperations
    {
        // Veritabanı bağlantı nesnesi
        public static SqlConnection connection = new SqlConnection("Data Source=EFIAVNI\\SQLEXPRESS;Initial Catalog=borsa;Integrated Security=True");

        // Bağlantıyı kontrol et ve açık değilse aç
        public static void CheckConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Genel bir SQL sorgusu çalıştırma ve sonucu DataTable olarak döndürme
        public static DataTable ExecuteQuery(string query)
        {
            // Bağlantıyı kontrol et ve aç
            CheckConnection();

            // SQL sorgusunu çalıştır
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
