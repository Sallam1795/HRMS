using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Services;

namespace test.Controllers
{
    [Authorize]
    public class SalaryReportController : Controller
    {
        private readonly ISalaryReportService salaryReportService;
        

        public SalaryReportController(ISalaryReportService salaryReportService)
        {
            this.salaryReportService = salaryReportService;
            
        }
        //public IActionResult getSalaryReportByYearMonth()
        //{            
        //    return PartialView("");
        //}
        public IActionResult Index(int year=2022,int month =3)
        {
            ViewData["Year"] = year;
            ViewData["Month"] = month;
            return View("Index", salaryReportService.Index( year,  month));
        }
        public IActionResult MonthDtails(int Id,int Month,int Year)
        {
            var emp=salaryReportService.SalaryReportServiceGetEmployee( Id);
            ViewData["Name"] = emp.Name;
            ViewData["Id"] = Id;
            return View(salaryReportService.SalaryReportMonthDtails(Id,Month,Year));
        }
        
    }
}
