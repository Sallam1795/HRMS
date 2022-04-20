using System;
using System.Collections.Generic;
using test.Models;

namespace test.Data.Repository
{
    public interface IWeeklyHolidayRepository
    {
        List<WeeklyHoliday> GetAll();
        WeeklyHoliday GetById(int id);
        int Update(int id, WeeklyHoliday weeklyHoliday);
        List<WeeklyHoliday> GetAllDaysOff();
        bool CheckIsWeeklyHoliday(DateTime dt);
    }
}