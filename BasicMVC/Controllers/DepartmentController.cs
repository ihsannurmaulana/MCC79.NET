using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class DepartmentController
    {
        private Department _department = new Department();
        private DepartmentView _departmentView = new DepartmentView();
        public void GetAll()
        {
            var departments = _department.GetAll();
            _departmentView.DisplayAll(departments);
        }
    }
}
