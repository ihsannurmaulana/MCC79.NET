using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class CountryController
    {
        private Country _country = new Country();
        private CountryView _countryView = new CountryView();
        private MainView _mainView = new MainView();


        public void MenuController()
        {
            bool isFinish = true;
            do
            {
                var countries = _country.GetAll();
                _countryView.DisplayAll(countries);
                _countryView.Menu();

                int InputPilihan = int.Parse(Console.ReadLine());

                try
                {
                    switch (InputPilihan)
                    {
                        case 1:
                            GetByID();
                            break;
                        case 2:
                            Insert();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
                            isFinish = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (isFinish);
        }

        public void GetByID()
        {
            _countryView.DisplayByID();
            string id = Console.ReadLine();

            var country = _country.GetByID(id);
            if (country == null)
            {
                _mainView.NotFound();
            }
            else
            {
                _countryView.DisplayByID(country);
            }
            Console.ReadKey();
        }

        public void Insert()
        {
            _countryView.DisplayByID();
            string id = Console.ReadLine();
            _countryView.DisplayName();
            string name = Console.ReadLine();
            _countryView.DisplayRegionID();
            int regionId = Convert.ToInt32(Console.ReadLine());

            int status = _country.Insert(id, name, regionId);
            if (status != 0)
            {
                _mainView.SuccessInsert();
            }
            else
            {
                _mainView.NotFound();
            }
            Console.ReadLine();
        }

        public void Update()
        {
            _countryView.DisplayByID();
            string id = Console.ReadLine();
            _countryView.DisplayName();
            string name = Console.ReadLine();
            _countryView.DisplayRegionID();
            int regionId = Convert.ToInt32(Console.ReadLine());


            int status = _country.Update(id, name, regionId);
            if (status != 0)
            {
                _mainView.SuccessUpdate();
            }
            else
            {
                _mainView.NotFound();
            }
            Console.ReadLine();
        }

        public void Delete()
        {
            _countryView.DisplayByID();
            string id = Console.ReadLine();

            int status = _country.Delete(id);
            if (status != 0)
            {
                _mainView.SuccessDelete();
            }
            else
            {
                _mainView.NotFound();
            }
            Console.ReadLine();
        }
    }
}
