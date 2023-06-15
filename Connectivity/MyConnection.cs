using System.Data.SqlClient;

namespace Connectivity
{
    public class MyConnection
    {
        static string connectionString = "Data Source=DESKTOP-8I1UG4L;Database=db_hr1;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        static SqlConnection connection;
        public static SqlConnection Get()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
