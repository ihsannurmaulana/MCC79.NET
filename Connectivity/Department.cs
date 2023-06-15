using System.Data.SqlClient;

namespace Connectivity
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        // GetAllLocation : Location
        public List<Department> GetAllDepartment()
        {

            SqlConnection conn = MyConnection.Get();
            var department = new List<Department>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_departments";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dep = new Department();
                        dep.Id = reader.GetInt32(0);
                        dep.Name = reader.GetString(1);
                        dep.LocationId = reader.GetInt32(2);
                        dep.ManagerId = reader.GetInt32(3);

                        department.Add(dep);// Menambahkan objek Department ke dalam list
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
            return department; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // Menu 
        public void DepartmentMenu()
        {
            Menu mMenu = new Menu();
            // GetAllDepartment : Department
            Console.Clear();
            Console.WriteLine("     All Data Department     ");
            List<Department> departments = GetAllDepartment();
            foreach (Department department in departments)
            {

                Console.WriteLine("Id : " + department.Id + ", Department Name : " + department.Name + ", Location ID : " + department.LocationId + ", Manager ID : " + department.ManagerId);
            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
