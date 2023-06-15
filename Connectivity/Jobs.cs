using System.Data.SqlClient;

namespace Connectivity
{
    class Jobs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        // GetAllLocation : Location
        public List<Jobs> GetAllJob()
        {

            SqlConnection conn = MyConnection.Get();
            var jobs = new List<Jobs>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);// Menambahkan objek Department ke dalam list
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            return jobs; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void JobMenu()
        {
            Menu menu = new Menu();
            // GetAll Jobs : Job
            Console.WriteLine("     All Data Jobs\n     ");
            List<Jobs> jobs = GetAllJob();
            foreach (Jobs job in jobs)
            {
                Console.WriteLine("");
                Console.WriteLine("ID : " + job.Id + ", Title : " + job.Title + ", Min Salary : " + job.MinSalary + ",  Max Salary : " + job.MaxSalary);
            }
            Console.ReadKey();
            menu.MainMenu();
        }
    }
}
