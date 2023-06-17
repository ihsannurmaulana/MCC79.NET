using System.Data.SqlClient;

namespace Connectivity
{
    public class Menu
    {
        SqlConnection connection = MyConnection.Get();


        public void MainMenu()
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
            try
            {
                Console.Write("Select Tabel : ");
                int InputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        new Country().CountryMenu();
                        break;
                    case 2:
                        new Region().Menu();
                        break;
                    case 3:
                        new Location().LocationMenu();
                        break;
                    case 4:
                        new Jobs().JobMenu();
                        break;
                    case 5:
                        new Department().DepartmentMenu();
                        break;
                    case 6:
                        new Employee().EmployeeMenu();
                        break;
                    case 7:
                        new History().HistoryMenu();
                        break;
                    case 8:
                        new Linq().LinqMenu();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.ReadKey();
                MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
