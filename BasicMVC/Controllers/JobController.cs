using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class JobController
    {
        private Job _jobs = new Job();
        private JobView _jobView = new JobView();
        public void GetAll()
        {
            var jobs = _jobs.GetAll();
            _jobView.DisplayAll(jobs);
        }
    }
}
