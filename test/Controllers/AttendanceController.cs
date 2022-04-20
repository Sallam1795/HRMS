using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using test.Services;
using test.ViewModel;

namespace test.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        
        {
            this.attendanceService = attendanceService;
        }

        public IActionResult Index()
        {
            
            return View(attendanceService.GetAllEmployeeService());
        }

        public IActionResult getEmployeeAttendance(int id)
        {
            
            return PartialView("_getEmployeeAttendance", attendanceService. GetEmployeeAttendanceService(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAttendance(AttendenceViewModel attendenceVM)
        {

            attendanceService.UpdateAttendanceService(attendenceVM);

            return RedirectToAction("Index");
        }


        public IActionResult TestTimeIfUnique(TimeSpan start, TimeSpan end)
        {
            if (start.Hours > end.Hours) 
            return Json(false);
            return Json(true);

        }

    }
}
