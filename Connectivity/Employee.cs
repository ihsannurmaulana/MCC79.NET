using System.Data.SqlClient;

namespace Connectivity
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal Comission { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        // GetAllLocation : Location
        public List<Employee> GetAllEmployee()
        {

            SqlConnection conn = MyConnection.Get();
            var employee = new List<Employee>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary = reader.GetInt32(6);
                        emp.Comission = reader.GetDecimal(7);
                        emp.ManagerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emp.JobId = reader.GetString(9);
                        emp.DepartmentId = reader.GetInt32(10);

                        employee.Add(emp);// Menambahkan objek Location ke dalam list
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
            return employee; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void EmployeeMenu()
        {
            Menu mMenu = new Menu();
            // GetAllEmployee : Employee
            Console.WriteLine("      All Data Employee     ");
            Console.WriteLine("----------------------------");
            List<Employee> employees = GetAllEmployee();
            foreach (Employee employee in employees)
            {

                Console.WriteLine("ID : " + employee.Id + ", First Name : " + employee.FirstName + ", Last Name : " + employee.LastName + ", Email : " + employee.Email + ", Phone Number : " + employee.PhoneNumber + ", Hire Date ID : " + employee.HireDate + ", Salary :  " + employee.Salary + ", Comission : " + employee.Comission + ", Manager ID : " + employee.ManagerId + "Job ID : " + employee.JobId + ", Department ID : " + employee.DepartmentId);
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
