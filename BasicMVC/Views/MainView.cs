namespace BasicMVC.Views
{
    public class MainView
    {
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("      Main Menu     ");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Countries");
            Console.WriteLine("2. Regions");
            Console.WriteLine("3. Locations");
            Console.WriteLine("4. Jobs");
            Console.WriteLine("5. Departments");
            Console.WriteLine("6. Employees");
            Console.WriteLine("7. Histories");
            Console.WriteLine("8. LINQ");
            Console.WriteLine("9. Exit");
        }

        public void NotFound()
        {
            Console.WriteLine("Data Not Found");
        }
    }
}
