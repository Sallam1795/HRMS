using System.Collections.Generic;
using test.ViewModel;

namespace test.Services
{
    public interface IAttendanceService
    {
        List<AttendenceViewModel> GetAllEmployeeService();
        AttendenceViewModel GetEmployeeAttendanceService(int id);
        void UpdateAttendanceService(AttendenceViewModel attendenceVM);
    }
}