using BasicMVC.Context;
using BasicMVC.Views;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        private MainView _mainView = new MainView();
        private MessageView _messageView = new MessageView();

        // GetAllLocation : Location
        public List<Job> GetAll()
        {
            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            var jobs = new List<Job>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Job();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);// Menambahkan objek Department ke dalam list
                    }
                }
                else
                {
                    _messageView.NotFound();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return jobs; // Mengembalikan list regions yang berisi objek-objek Region
        }
    }
}
