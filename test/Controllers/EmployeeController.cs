using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Services;

namespace test.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult GetAllEmployees()
        {
            
            return View(employeeService.EmployeesServiceGetAll());
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.EmployeeServiceAddEmployee(employee);
                return RedirectToAction("GetAllEmployees");
            }
            return View();
        }

        [HttpGet]
        public IActionResult updateEmployee(int id)
        {
            return View(employeeService.EmployeeServiceGetUpdate(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult updateEmployee(int id,Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.EmployeeServicePostUpdate(id, employee);
                return RedirectToAction(nameof(GetAllEmployees));
            }
            return View("updateEmployee", employee.Id);
        }

        [HttpGet]
        public IActionResult DetailsEmployee(int id)
        {
            return View(employeeService.EmployeeServiceDetails(id));
        }
        
        public IActionResult DeleteEmployee(int id)
        {
            employeeService.EmployeeServiceDelete(id);
            return RedirectToAction("GetAllEmployees");
        }

    }
}
