using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class CountryController
    {
        private Country _country = new Country();
        private CountryView _countryView = new CountryView();

        public void GetAll()
        {
            var countries = _country.GetAll();
            _countryView.DisplayAll(countries);
        }
    }
}
