namespace test.Services
{
    public interface IAccountService
    {
        bool AccountServiceCheckHolidaysAndAleadyLogged();
        void AccountServiceMakeAllEmployeeAbsent();
    }
}