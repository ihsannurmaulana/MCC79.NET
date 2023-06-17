using BasicMVC.Controllers;
using BasicMVC.Models;

namespace BasicMVC.Views
{
    public class RegionView
    {

        public void DisplayAll(List<Region> regions)
        {
            Console.Clear();
            Console.WriteLine("     All Data Regions     ");
            Console.WriteLine("--------------------------");

            foreach (Region region in regions)
            {
                Console.WriteLine("ID : " + region.Id);
                Console.WriteLine("Name : " + region.Name);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to back");
            Console.ReadKey();
            new MenuController().MainMenu();
        }
        public int DisplayByID()
        {
            Console.WriteLine("Get Region By ID");
            Console.WriteLine("=========================");
            Console.Write("Select region By ID : ");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        public void DisplayByID(Region region)
        {
            Console.WriteLine("ID : " + region.Id + ", Name : " + region.Name);
        }
    }


}
