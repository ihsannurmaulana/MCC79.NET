using BasicMVC.Context;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // GetAll : Region
        public List<Region> GetAll()
        {
            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            var regions = new List<Region>();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region();
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
                        regions.Add(region);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return regions;
        }

        public Region GetByID(int id)
        {
            SqlConnection connection = Connectivity.Connection();
            connection.Open();

            var regions = new Region();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    regions.Id = reader.GetInt32(0);
                    regions.Name = reader.GetString(1);
                }
                else
                {
                    regions = new Region();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return regions;
        }
    }
}
