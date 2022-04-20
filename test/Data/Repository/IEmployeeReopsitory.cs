using System.Collections.Generic;
using test.Models;

namespace test.Data.Repository
{
    public interface IEmployeeReopsitory
    {
        int Delete(int id);
        List<Employee> GetAll();
        Employee GetById(int id);
        Employee GetByName(string name);
        int Insert(Employee employee);
        int Update(int id, Employee employeeEdit);
    }
}