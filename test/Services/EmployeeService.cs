using System;
using System.Collections.Generic;
using test.Data.Repository;
using test.Models;

namespace test.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeReopsitory _employeeReopsitory;
        IAttendanceRepository _attendanceRepository;
        public EmployeeService(IEmployeeReopsitory employeeReopsitory, IAttendanceRepository attendanceRepository)
        {
            _employeeReopsitory = employeeReopsitory;
            _attendanceRepository = attendanceRepository;
        }
        public List<Employee> EmployeesServiceGetAll()
        {
            return _employeeReopsitory.GetAll();
        }
        public void EmployeeServiceAddEmployee(Employee employee)
        {
            _employeeReopsitory.Insert(employee);
            DateTime dt = new DateTime(employee.StartWork.Year, employee.StartWork.Month, 1);
            for (; dt <= employee.StartWork; dt = dt.AddDays(1))
            {
                Attendance att = new Attendance()
                {
                    Absent = 1,
                    Attend = 0,
                    CheckIn = new System.TimeSpan(),
                    CheckOut = new System.TimeSpan(),
                    DiscountTime = System.TimeSpan.Zero,
                    OverTime = System.TimeSpan.Zero,
                    EmployeeId = employee.Id,
                    Date = dt
                };
                _attendanceRepository.Insert(att);
            }
        }
        public Employee EmployeeServiceGetUpdate(int id)
        {
            return _employeeReopsitory.GetById(id);
        }
        public void EmployeeServicePostUpdate(int id, Employee employee)
        {
            _employeeReopsitory.Update(id, employee);
        }
        public Employee EmployeeServiceDetails(int id)
        {
            return _employeeReopsitory.GetById(id);
        }
        public void EmployeeServiceDelete(int id)
        {
            _employeeReopsitory.Delete(id);
        }
    }
}
