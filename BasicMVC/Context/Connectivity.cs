using System.Data.SqlClient;

namespace BasicMVC.Context
{
    public class Connectivity
    {
        private static string connectionString = "Data Source=DESKTOP-8I1UG4L;Database = db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static SqlConnection Connection()
        {
            return new SqlConnection(connectionString);
        }



    }
}
