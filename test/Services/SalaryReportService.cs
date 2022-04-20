using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using test.Data.Repository;
using test.Data.ViewModels;
using test.Models;

namespace test.Services
{
    public class SalaryReportService : ISalaryReportService
    {
        IEmployeeReopsitory _employeeReopsitory;
        IHolidayRepository _holidayRepository;
        IAttendanceRepository _attendanceRepository;
        private readonly IExtraAndDiscountRepository _extraAndDiscountRepository;

        public SalaryReportService(IEmployeeReopsitory employeeReopsitory, IHolidayRepository holidayRepository,
            IAttendanceRepository attendanceRepository, IExtraAndDiscountRepository extraAndDiscountRepository)
        {
            _employeeReopsitory = employeeReopsitory;
            _holidayRepository = holidayRepository;
            _attendanceRepository = attendanceRepository;
            _extraAndDiscountRepository = extraAndDiscountRepository;
        }

        public List<SalaryReportViewModel> Index(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, daysInMonth);

            List<SalaryReportViewModel> salaryReports = new List<SalaryReportViewModel> { };
            List<Attendance> attendances = _attendanceRepository.GetAll();
            List<Employee> employees = _employeeReopsitory.GetAll();


            var EmployeeMonthlyReport = attendances.Where(x => x.Date >= startDate && x.Date < endDate).GroupBy(x => x.EmployeeId).Select(x =>
                   new
                   {
                       EmployeeId = x.Key,
                       AbsentDays = x.Count(x => x.Absent == 1),
                       AttendDays = x.Count(x => x.Attend == 1),
                       overTime = x.Sum(x => x.OverTime.TotalHours),
                       discountTime = x.Sum(x => x.DiscountTime.TotalHours)
                   }).ToList();

            foreach (var attendanceData in EmployeeMonthlyReport)
            {
                var empId = attendanceData.EmployeeId;
                var empName = employees.Find(e => e.Id == empId).Name;
                var empPhone = employees.Find(e => e.Id == empId).PhoneNumber;
                double empSalary = employees.Find(e => e.Id == empId).Salary;
                double salaryBerHour = (empSalary / daysInMonth) / 8;


                salaryReports.Add(new SalaryReportViewModel
                {

                    Id = empId,
                    Name = empName,
                    Salary = empSalary,
                    Phone = empPhone,
                    DateSearched = startDate,

                    AttendanceDays = attendanceData.AttendDays,
                    AbsentDays = attendanceData.AbsentDays,
                    OverTimeHours = Math.Round(attendanceData.overTime, 2),
                    DiscountHours = Math.Round(attendanceData.discountTime, 2),

                    Extra = CalcOverTimeBouns(attendanceData.overTime, salaryBerHour),
                    Discount = CalcDeductionHours(attendanceData.discountTime, salaryBerHour),

                    Total = CalcTotalSalary(empSalary, attendanceData.overTime, salaryBerHour,
                                             attendanceData.discountTime,daysInMonth, attendanceData.AbsentDays)
                    
                });
            }
            return salaryReports;
        }

       
        public List<Attendance> SalaryReportMonthDtails(int Id, int Month, int Year)
        {
            DateTime dt = new DateTime(Year, Month, 1);
            return _attendanceRepository.GetMonthlyAttendance(Id, dt);
        }
        public Employee SalaryReportServiceGetEmployee(int id)
        {
            return _employeeReopsitory.GetById(id);
        }
        public double CalcOverTimeBouns(double overTime, double salaryBerHour)
        {
            return Math.Truncate(_extraAndDiscountRepository.GetExtraAndDiscount().Extra * salaryBerHour * overTime);
        }
        public double CalcDeductionHours(double DeductionTime, double salaryBerHour)
        {
            return Math.Truncate(_extraAndDiscountRepository.GetExtraAndDiscount().Discount * salaryBerHour * DeductionTime);
        }
        public double CalcTotalSalary(double empSalary, double overTime, double salaryBerHour, double discountTime, int daysInMonth, int AbsentDays)
        {
            return Math.Truncate(empSalary + CalcOverTimeBouns(overTime, salaryBerHour) -
                             CalcDeductionHours(discountTime, salaryBerHour)
                             - ((empSalary / daysInMonth) * AbsentDays) -
                             (empSalary / daysInMonth) * (daysInMonth - DateTime.Now.Day));
        }
    }
}
