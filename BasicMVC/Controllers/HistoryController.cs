using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class HistoryController
    {
        private History _history = new History();
        private HistoryView _historyView = new HistoryView();
        public void GetAll()
        {
            var history = _history.GetAll();
            _historyView.DisplayAll(history);
        }
    }
}
