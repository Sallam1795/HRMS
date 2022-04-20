using System.Collections.Generic;
using test.Data.Repository;
using test.Models;

namespace test.Services
{
    public class HolidayService : IHolidayService
    {
        IHolidayRepository _holidayRepository;
        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }
        public List<Holidays> HolidayServiceGetAll()
        {
            return _holidayRepository.GetAll();
        }
        public void HolidayServiceAddHoliday(Holidays holiday)
        {
            _holidayRepository.Insert(holiday);
        }
        public Holidays HolidayServiceGetUpdateHoliday(int id)
        {
            return _holidayRepository.GetById(id);
        }
        public void HolidayServicePostUpdateHoliday(int id, Holidays holidays)
        {
            _holidayRepository.Update(id, holidays);
        }
    }
}
