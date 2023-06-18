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
        }

        public void DisplayByID()
        {
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.Write("Input ID : ");
        }

        public void DisplayByID(Country country)
        {
            Console.WriteLine("ID : " + country.Id + ", Name : " + country.Name + ",Region ID : " + country.RegionId);
        }

        public void DisplayName()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.Write("Insert Country Name : ");
        }

        public void DisplayRegionID()
        {
            Console.WriteLine("------------------");
            Console.Write("Input Region ID : ");
        }
    }
}
