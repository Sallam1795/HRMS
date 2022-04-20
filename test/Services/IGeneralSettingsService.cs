using test.Data.ViewModels;

namespace test.Services
{
    public interface IGeneralSettingsService
    {
        GeneralSettingsViewModel GSServiceIndex();
        void GSServiceUpdate(GeneralSettingsViewModel generalSettingVM);
    }
}