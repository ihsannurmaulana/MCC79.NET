using BasicMVC.Context;
using BasicMVC.Views;
using System.Data;
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
        public Country GetByID(string id)
        {
            connection.Open();
            var country = new Country();
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
                    reader.Read();

                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MainView.ErrorHandling(ex);
            }

            connection.Close();
            return country; // Mengembalikan list countries yang berisi objek-objek Country
        }

        public int Insert(string id, string name, int regionId)
        {
            int result = 0;

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@countries_id, @countries_name, @countries_region_id)";
                command.Transaction = transaction;


                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@countries_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                // Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@countries_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;
                // Membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@countries_region_id";
                pRegionId.Value = regionId;
                pRegionId.SqlDbType = SqlDbType.VarChar;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRegionId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;
        }

        public int Update(string id, string name, int regionId)
        {
            int result = 0;

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_countries SET id = @id, name = @name, region_id = @region_id WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@name";
                pNewName.Value = name;
                pNewName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = regionId;
                pRegionId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pNewName);
                command.Parameters.Add(pRegionId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MainView.ErrorHandling(ex);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;
        }

        public int Delete(string id)
        {
            int result = 0;

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_countries WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;
        }
    }
}
