using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class LocationView
    {
        public void DisplayAll(List<Location> locations)
        {
            Console.Clear();
            Console.WriteLine("     All Data Location     ");
            Console.WriteLine("---------------------------");

            foreach (Location location in locations)
            {
                Console.WriteLine("ID\t\t: " + location.Id);
                Console.WriteLine("Stree Address\t: " + location.StreetAddress);
                Console.WriteLine("Postal Code\t: " + location.PostalCode);
                Console.WriteLine("City\t\t: " + location.City);
                Console.WriteLine("State Province  : " + location.StateProvince);
                Console.WriteLine("Country ID\t: " + location.CountryId);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
    }
}
