using BasicMVC.Models;
using BasicMVC.Views;

namespace BasicMVC.Controllers
{
    public class EmployeeController
    {
        private Employee _employee = new Employee();
        private EmployeeView _employeeView = new EmployeeView();
        public void GetAll()
        {
            var employees = _employee.GetAll();
            _employeeView.DisplayAll(employees);
        }
    }
}
