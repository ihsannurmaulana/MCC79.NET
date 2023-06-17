using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class DepartmentView
    {
        public void DisplayAll(List<Department> departments)
        {
            Console.Clear();
            Console.WriteLine("     All Data Department     ");
            Console.WriteLine("-----------------------------");

            foreach (Department department in departments)
            {
                Console.WriteLine("ID\t\t : " + department.Id);
                Console.WriteLine("Departement Name : " + department.Name);
                Console.WriteLine("Location ID\t : " + department.LocationId);
                Console.WriteLine("Manager ID \t : " + department.ManagerId);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
