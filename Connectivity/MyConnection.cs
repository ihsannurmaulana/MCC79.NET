using System.Data.SqlClient;

namespace Connectivity
{
    public class MyConnection
    {
        private static string connectionString = "Data Source=DESKTOP-8I1UG4L;Database=db_hr1;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static SqlConnection Get()
        {
            return new SqlConnection(connectionString);
        }
    }
}
