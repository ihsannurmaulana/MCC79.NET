using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class CountryView
    {
        public void DisplayAll(List<Country> countries)
        {
            Console.Clear();
            Console.WriteLine("       All Data Country      ");
            Console.WriteLine("-----------------------------");

            foreach (Country country in countries)
            {
                Console.WriteLine("ID\t\t: " + country.Id);
                Console.WriteLine("Country Name\t: " + country.Name);
                Console.WriteLine("Region ID\t: " + country.RegionId);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
