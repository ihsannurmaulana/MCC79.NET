using BasicMVC.Context;
using BasicMVC.Views;
using System.Data;
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
                MessageView.ErrorHandling(ex);
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
                MessageView.ErrorHandling(ex);
            }

            connection.Close();
            return regions;
        }

        public int Insert(string name)
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
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = (name == "") ? null : name;
                pName.SqlDbType = SqlDbType.VarChar;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageView.ErrorHandling(ex);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    MessageView.ErrorHandling(ex);
                }
            }

            connection.Close();
            return result;

        }

        public int Update(int id, string name)
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
                command.CommandText = "UPDATE tb_m_regions SET name = @newName WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.Value = (name == "") ? null : name;
                pNewName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = (id == 0) ? null : id;
                pId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pNewName);
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageView.ErrorHandling(ex);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    MessageView.ErrorHandling(ex);
                }
            }

            connection.Close();
            return result;
        }

        public int Delete(int id)
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
                command.CommandText = "DELETE FROM tb_m_regions WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageView.ErrorHandling(ex);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    MessageView.ErrorHandling(ex);
                }
            }

            connection.Close();
            return result;
        }
    }
}
