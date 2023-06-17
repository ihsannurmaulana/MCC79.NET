using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class RegionController
    {
        private Region _region = new Region();
        private MainView _mainView = new MainView();
        private RegionView _regionView = new RegionView();

        // GetAll : Region
        public void GetAll()
        {
            var regions = _region.GetAll();
            _regionView.DisplayAll(regions);
        }

        // Get ByID : Region
        public void GetByID()
        {
            int id = _regionView.DisplayByID();

            var region = _region.GetByID(id);

            if (region == null)
            {
                _mainView.NotFound();
            }
            else
            {
                _regionView.DisplayByID(region);
            }
            Console.ReadKey();
        }




    }
}
