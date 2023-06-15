using System.Data.SqlClient;

namespace Connectivity
{
    class Location
    {

        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }


        // GetAllLocation : Location
        public List<Location> GetAllLocation()
        {

            SqlConnection conn = MyConnection.Get();
            var location = new List<Location>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_locations";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Location();
                        loc.Id = reader.GetInt32(0);
                        loc.StreetAddress = reader.GetString(1);
                        loc.PostalCode = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.StateProvince = reader.GetString(4);
                        loc.CountryId = reader.GetString(5);

                        location.Add(loc);// Menambahkan objek Location ke dalam list
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
            return location; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void LocationMenu()
        {
            Menu mMenu = new Menu();
            Console.Clear();
            Console.WriteLine("     All Data Location     ");
            List<Location> locations = GetAllLocation();
            foreach (Location location in locations)
            {

                Console.WriteLine("Id : " + location.Id + ", Street Addres : " + location.StreetAddress + ", Postal Code : " + location.PostalCode + ", City : " + location.City + ", State Province : " + location.StateProvince + ", Country ID : " + location.CountryId);
            }
            Console.ReadKey();
            mMenu.MainMenu();
        }

    }
}
