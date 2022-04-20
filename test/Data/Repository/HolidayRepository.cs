using System;
using System.Collections.Generic;
using System.Linq;
using test.Models;

namespace test.Data.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        ApplicationDbContext applicationDbContext;
        public HolidayRepository(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;
        }
        public List<Holidays> GetAll()
        {
            List<Holidays> holdaiesList = applicationDbContext.Holidays.ToList();
            return holdaiesList;
        }
        public Holidays GetById(int id)
        {
            Holidays holidays = applicationDbContext.Holidays.FirstOrDefault(x => x.Id == id);
            return holidays;
        }
        public bool CheckIsHoliday(DateTime dt)
        {
            List<Holidays> holidies = GetAll();
            foreach (var holiday in holidies)
            {
                if (holiday.Date == dt.Date)
                {
                    return true;
                }
            }
           
            return false;
        }

        public int Insert(Holidays holidays)
        {
            applicationDbContext.Holidays.Add(holidays);
            int holidayes = applicationDbContext.SaveChanges();
            return holidayes;
        }
        public int Update(int id, Holidays holidays)
        {
            Holidays oldHoldays = applicationDbContext.Holidays.FirstOrDefault(s => s.Id == id);
            oldHoldays.Id = holidays.Id;
            oldHoldays.Name = holidays.Name;
            oldHoldays.Date = holidays.Date;
            int UpdateHoliday = applicationDbContext.SaveChanges();
            return UpdateHoliday;
        }
        public int Delete(int id)
        {
            Holidays deleteHoliday = applicationDbContext.Holidays.FirstOrDefault(s => s.Id == id);
            applicationDbContext.Holidays.Remove(deleteHoliday);
            int deleteeHoliday = applicationDbContext.SaveChanges();
            return deleteeHoliday;
        }
    }
}
