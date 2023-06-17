using BasicMVC.Context;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        SqlConnection connection = Connectivity.Connection();

        // GetAllCountry : Country
        public List<Country> GetAll()
        {
            connection.Open();
            var countries = new List<Country>();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                        countries.Add(country); // Menambahkan objek Region ke dalam list
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
            connection.Close();
            return countries; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // GetCountryByID : Country
        public List<Country> GetByID(string id)
        {
            connection.Open();
            var countries = new List<Country>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                        countries.Add(country); // Menambahkan objek Country ke dalam list
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

            connection.Close();
            return countries; // Mengembalikan list countries yang berisi objek-objek Country
        }
    }
}
