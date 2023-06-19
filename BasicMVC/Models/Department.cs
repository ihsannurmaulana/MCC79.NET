using BasicMVC.Context;
using BasicMVC.Views;
using System.Data.SqlClient;

namespace BasicMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }
        public List<Department> GetAll()
        {

            SqlConnection connection = Connectivity.Connection();
            connection.Open();
            var departments = new List<Department>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_departments";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new Department();
                        department.Id = reader.GetInt32(0);
                        department.Name = reader.GetString(1);
                        department.LocationId = reader.GetInt32(2);
                        department.ManagerId = reader.GetInt32(3);

                        departments.Add(department);// Menambahkan objek Department ke dalam list
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
            return departments; // Mengembalikan list regions yang berisi objek-objek Region
        }
    }
}
