using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class LocationController
    {
        private Location _location = new Location();
        private LocationView _locationView = new LocationView();
        public void GetAll()
        {
            var locations = _location.GetAll();
            _locationView.DisplayAll(locations);
        }
    }
}
