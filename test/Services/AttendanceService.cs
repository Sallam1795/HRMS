using System;
using System.Collections.Generic;
using test.Data.Repository;
using test.Models;
using test.ViewModel;

namespace test.Services
{
    public class AttendanceService : IAttendanceService
    {
        IAttendanceRepository _attendanceRepository;
        IEmployeeReopsitory _employeeReopsitory;
        public AttendanceService(IAttendanceRepository attendaceReposatory, IEmployeeReopsitory employeeReposatory)

        {
            _attendanceRepository = attendaceReposatory;
            _employeeReopsitory = employeeReposatory;
        }
        public List<AttendenceViewModel> GetAllEmployeeService()
        {
            List<AttendenceViewModel> attendenceData = new();
            List<Employee> employees = _employeeReopsitory.GetAll();
            List<Attendance> attendances = _attendanceRepository.GetAllByDate(DateTime.Now.Date);


            foreach (var att in attendances)
            {
                var empId = employees.Find(e => e.Id == att.EmployeeId).Id;
                var empName = employees.Find(e => e.Id == att.EmployeeId).Name;

                attendenceData.Add(new AttendenceViewModel
                {
                    Id = empId,
                    Name = empName,
                    Date = att.Date,
                    CheckIn = att.CheckIn,
                    CheckOut = att.CheckOut
                });
            }
            return attendenceData;
        }
        public AttendenceViewModel GetEmployeeAttendanceService(int id)
        {
            Attendance attendance = _attendanceRepository.GetEmployeeId(id);
            Employee employee = _employeeReopsitory.GetById(id);
            AttendenceViewModel attendenceData = new AttendenceViewModel
            {
                Id = attendance.Id,
                Name = employee.Name,
                Date = attendance.Date,
                CheckIn = attendance.CheckIn,
                CheckOut = attendance.CheckOut
            };
            return attendenceData;
        }
        public void UpdateAttendanceService(AttendenceViewModel attendenceVM)
        {
            Attendance attendance = _attendanceRepository.GetEmployeeId(attendenceVM.Id);
            attendance.Date = attendenceVM.Date;
            attendance.Absent = 0;
            attendance.Attend = 1;
            attendance.CheckIn = attendenceVM.CheckIn;
            attendance.CheckOut = attendenceVM.CheckOut;
            TimeSpan attendTime = new TimeSpan(09, 00, 00);
            TimeSpan leaveTime = new TimeSpan(17, 00, 00);
            if (attendenceVM.CheckIn > attendTime)
            {
                attendance.DiscountTime = attendenceVM.CheckIn.Subtract(attendTime);
            }
            if (attendenceVM.CheckOut > leaveTime)
            {
                attendance.OverTime = attendenceVM.CheckOut.Subtract(leaveTime);
            }

            _attendanceRepository.Update(attendance.Id, attendance);

        }
    }
}
