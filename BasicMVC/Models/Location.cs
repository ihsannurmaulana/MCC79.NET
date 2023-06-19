using BasicMVC.Context;
using BasicMVC.Views;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }


        // GetAllLocation : Location
        public List<Location> GetAll()
        {

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            var locations = new List<Location>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_locations";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new Location();
                        location.Id = reader.GetInt32(0);
                        location.StreetAddress = reader.GetString(1);
                        location.PostalCode = reader.GetString(2);
                        location.City = reader.GetString(3);
                        location.StateProvince = reader.GetString(4);
                        location.CountryId = reader.GetString(5);

                        locations.Add(location);// Menambahkan objek Location ke dalam list
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
            return locations; // Mengembalikan list regions yang berisi objek-objek Region
        }
    }
}
