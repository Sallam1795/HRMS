using System.Collections.Generic;
using test.Models;

namespace test.Services
{
    public interface IHolidayService
    {
        void HolidayServiceAddHoliday(Holidays holiday);
        List<Holidays> HolidayServiceGetAll();
        Holidays HolidayServiceGetUpdateHoliday(int id);
        void HolidayServicePostUpdateHoliday(int id, Holidays holidays);
    }
}