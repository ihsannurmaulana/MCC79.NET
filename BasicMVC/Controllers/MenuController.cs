using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class MenuController
    {
        private MainView _menuView = new MainView();
        private CountryController _countryController = new CountryController();
        private RegionController _regionController = new RegionController();
        private LocationController _location = new LocationController();
        private JobController _jobController = new JobController();
        private DepartmentController _departmentController = new DepartmentController();
        private EmployeeController _employeeController = new EmployeeController();
        private HistoryController _historyController = new HistoryController();

        public void MainMenu()
        {
            _menuView.DisplayMainMenu();
            int inputPilihan = Convert.ToInt32(Console.ReadLine());

            bool isFinish = true;
            do
            {
                switch (inputPilihan)
                {
                    case 1:
                        _countryController.MenuController();
                        break;
                    case 2:
                        _regionController.MenuController();
                        break;
                    case 3:
                        _location.GetAll();
                        break;
                    case 4:
                        _jobController.GetAll();
                        break;
                    case 5:
                        _departmentController.GetAll();
                        break;
                    case 6:
                        _employeeController.GetAll();
                        break;
                    case 7:
                        _historyController.GetAll();
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
            } while (isFinish);

        }
    }
}
