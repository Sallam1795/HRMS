using System;
using System.Collections.Generic;
using test.Models;

namespace test.Data.Repository
{
    public interface IHolidayRepository
    {
        int Delete(int id);
        List<Holidays> GetAll();
        Holidays GetById(int id);
        int Insert(Holidays holidays);
        int Update(int id, Holidays holidays);
        bool CheckIsHoliday(DateTime dt);
    }
}