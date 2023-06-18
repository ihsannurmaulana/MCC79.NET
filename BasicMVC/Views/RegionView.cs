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
        }
        public void DisplayByID()
        {
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.Write("Input ID : ");
        }
        public void DisplayByID(Region region)
        {
            Console.WriteLine("ID : " + region.Id + ", Name : " + region.Name);
        }

        public void DisplayName()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.Write("Insert Name : ");
        }


    }
}
