using System;
using System.Collections.Generic;
using test.Data.Repository;
using test.Models;

namespace test.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IEmployeeReopsitory employeeRepository;
        private readonly IHolidayRepository holidayRepository;
        private readonly IWeeklyHolidayRepository weeklyHolidayRepository;
        public AccountService(IAttendanceRepository attendanceRepository, IEmployeeReopsitory employeeRepository,
            IHolidayRepository holidayRepository, IWeeklyHolidayRepository weeklyHolidayRepository)
        {
            this.holidayRepository = holidayRepository;
            this.attendanceRepository = attendanceRepository;
            this.employeeRepository = employeeRepository;
            this.weeklyHolidayRepository = weeklyHolidayRepository;
        }

        public bool AccountServiceCheckHolidaysAndAleadyLogged()
        {
            DateTime dt = DateTime.Now.Date;
            if (attendanceRepository.IsDateExist(dt) || holidayRepository.CheckIsHoliday(dt) || weeklyHolidayRepository.CheckIsWeeklyHoliday(dt))
            {
                return true;
            }
            return false;
        }
        public void AccountServiceMakeAllEmployeeAbsent()
        {
            List<Employee> employees = employeeRepository.GetAll();
            foreach (var emp in employees)
            {
                attendanceRepository.Insert(new Attendance
                {
                    Date = DateTime.Now.Date,
                    CheckOut = new TimeSpan(),
                    CheckIn = new TimeSpan(),
                    OverTime = new TimeSpan(),
                    DiscountTime = new TimeSpan(),
                    Attend = 0,
                    Absent = 1,
                    EmployeeId = emp.Id
                });


            }
        }
    }
}
