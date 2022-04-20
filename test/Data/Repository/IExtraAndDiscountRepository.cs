using test.Models;

namespace test.Data.Repository
{
    public interface IExtraAndDiscountRepository
    {
        ExtraAndDiscount GetExtraAndDiscount();
        int Update(ExtraAndDiscount extraAndDiscount);
    }
}