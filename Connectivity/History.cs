using System.Data.SqlClient;

namespace Connectivity
{
    class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        // GetAllLocation : Location
        public List<History> GetAllHistories()
        {

            SqlConnection conn = MyConnection.Get();
            var history = new List<History>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
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
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            conn.Close();
            return history; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void HistoryMenu()
        {
            Menu mMenu = new Menu();

            // GetAllHistoy : Histories
            Console.WriteLine("     All Data Histories     ");
            Console.WriteLine("----------------------------");
            List<History> histories = GetAllHistories();
            foreach (History history in histories)
            {

                Console.WriteLine("Employee_ID : " + history.EmployeeId + ", Start_Date : " + history.StartDate + ", End_Date : " + history.EndDate + ",  Department ID : " + history.DepartmentId + ", Job_ID : " + history.JobId);
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
