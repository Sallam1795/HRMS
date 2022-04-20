using System.Collections.Generic;
using test.Models;

namespace test.Services
{
    public interface IEmployeeService
    {
        void EmployeeServiceAddEmployee(Employee employee);
        void EmployeeServiceDelete(int id);
        Employee EmployeeServiceDetails(int id);
        Employee EmployeeServiceGetUpdate(int id);
        void EmployeeServicePostUpdate(int id, Employee employee);
        List<Employee> EmployeesServiceGetAll();
    }
}