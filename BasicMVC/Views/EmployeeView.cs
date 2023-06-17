using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class EmployeeView
    {
        public void DisplayAll(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("      All Data Employee     ");
            Console.WriteLine("----------------------------");

            foreach (Employee employee in employees)
            {
                Console.WriteLine("ID\t\t: " + employee.Id);
                Console.WriteLine("Firt Name\t: " + employee.FirstName);
                Console.WriteLine("Last Name\t: " + employee.LastName);
                Console.WriteLine("Email\t\t: " + employee.Email);
                Console.WriteLine("Phone Number\t: " + employee.PhoneNumber);
                Console.WriteLine("Hire Date\t: " + employee.HireDate);
                Console.WriteLine("Salary\t\t: " + employee.Salary);
                Console.WriteLine("Comission\t: " + employee.Comission);
                Console.WriteLine("Manager ID\t: " + employee.ManagerId);
                Console.WriteLine("Job ID\t\t: " + employee.JobId);
                Console.WriteLine("Department ID\t: " + employee.DepartmentId);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
