using BasicMVC.Context;
using BasicMVC.Views;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        // GetAllLocation : Location
        public List<History> GetAll()
        {

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            var history = new List<History>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var histori = new History();
                        histori.StartDate = reader.GetDateTime(0);
                        histori.EmployeeId = reader.GetInt32(1);
                        histori.EndDate = reader.GetDateTime(2);
                        histori.DepartmentId = reader.GetInt32(3);
                        histori.JobId = reader.GetString(4);

                        history.Add(histori);// Menambahkan objek Department ke dalam list
                    }
                }
                else
                {
                    new MessageView().NotFound();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return history; // Mengembalikan list regions yang berisi objek-objek Region
        }
    }
}
