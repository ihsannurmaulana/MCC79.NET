using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class HistoryView
    {
        public void DisplayAll(List<History> history)
        {

            Console.Clear();
            Console.WriteLine("     All Data Histories     ");
            Console.WriteLine("----------------------------");

            foreach (History histori in history)
            {
                Console.WriteLine("Employe ID\t: " + histori.EmployeeId);
                Console.WriteLine("Start Date\t: " + histori.StartDate);
                Console.WriteLine("End Date\t: " + histori.EndDate);
                Console.WriteLine("Department ID   : " + histori.DepartmentId);
                Console.WriteLine("Job ID\t\t: " + histori.JobId);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
