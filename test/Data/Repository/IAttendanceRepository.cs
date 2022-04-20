using System;
using System.Collections.Generic;
using test.Models;

namespace test.Data.Repository
{
    public interface IAttendanceRepository
    {
        int Delete(int id);
        List<Attendance> GetAll();
        Attendance GetById(int id);
        int Insert(Attendance attendance);
        int Update(int id, Attendance attendanceEdit);
        bool IsDateExist(DateTime date);
        List<Attendance> GetAllByDate(DateTime date);
        Attendance GetEmployeeId(int id);
        List<Attendance> GetMonthlyAttendance(int id, DateTime dt);

    }
}