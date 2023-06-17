using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class JobView
    {
        public void DisplayAll(List<Job> jobs)
        {
            Console.Clear();
            Console.WriteLine("     All Data Job     ");
            Console.WriteLine("----------------------");

            foreach (Job job in jobs)
            {
                Console.WriteLine("ID\t   : " + job.Id);
                Console.WriteLine("Name\t   : " + job.Title);
                Console.WriteLine("Min Salary : " + job.MinSalary);
                Console.WriteLine("Max Salary : " + job.MaxSalary);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
