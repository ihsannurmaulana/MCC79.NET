using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class MenuController
    {
        private MainView _menuView = new MainView();

        public void MainMenu()
        {
            _menuView.DisplayMainMenu();
            try
            {
                Console.Write("Select Tabel: ");
                int inputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (inputPilihan)
                {
                    case 1:
                        new CountryController().GetAll();
                        break;
                    case 2:
                        new RegionController().GetAll();
                        break;
                    case 3:
                        new LocationController().GetAll();
                        break;
                    case 4:
                        new JobController().GetAll();
                        break;
                    case 5:
                        new DepartmentController().GetAll();
                        break;
                    case 6:
                        new EmployeeController().GetAll();
                        break;
                    case 7:
                        new HistoryController().GetAll();
                        break;
                    //case 8:
                    //    new LinqController().LinqMenu();
                    //    break;
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
