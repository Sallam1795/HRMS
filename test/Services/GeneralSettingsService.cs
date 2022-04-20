using test.Data.Repository;
using test.Data.ViewModels;
using test.Models;

namespace test.Services
{
    public class GeneralSettingsService : IGeneralSettingsService
    {
        IWeeklyHolidayRepository _weeklyHolidayRepository;
        IExtraAndDiscountRepository _extraAndDiscountRepository;
        public GeneralSettingsService(IWeeklyHolidayRepository weeklyHolidayRepository, IExtraAndDiscountRepository extraAndDiscountRepository)
        {
            _weeklyHolidayRepository = weeklyHolidayRepository;
            _extraAndDiscountRepository = extraAndDiscountRepository;
        }

        public GeneralSettingsViewModel GSServiceIndex()
        {
            GeneralSettingsViewModel generalSettingVM = new GeneralSettingsViewModel();
            ExtraAndDiscount extraDiscount = _extraAndDiscountRepository.GetExtraAndDiscount();
            generalSettingVM.Extra = extraDiscount.Extra;
            generalSettingVM.Discount = extraDiscount.Discount;
            generalSettingVM.weeklyHolidays = _weeklyHolidayRepository.GetAll();
            return generalSettingVM;
        }

        public void GSServiceUpdate(GeneralSettingsViewModel generalSettingVM)
        {
            ExtraAndDiscount extraDiscount = new ExtraAndDiscount() { Extra = generalSettingVM.Extra, Discount = generalSettingVM.Discount };
            _extraAndDiscountRepository.Update(extraDiscount);
            foreach (var holiday in generalSettingVM.weeklyHolidays)
            {
                _weeklyHolidayRepository.Update(holiday.Id, holiday);

            }
        }

    }
}
