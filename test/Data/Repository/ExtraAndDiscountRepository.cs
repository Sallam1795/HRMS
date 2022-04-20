using System.Collections.Generic;
using System.Linq;
using test.Models;

namespace test.Data.Repository
{
    public class ExtraAndDiscountRepository : IExtraAndDiscountRepository
    {
        ApplicationDbContext applicationDbContext;
        public ExtraAndDiscountRepository(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;
        }


        public ExtraAndDiscount GetExtraAndDiscount()
        {
            ExtraAndDiscount extraAndDiscount = applicationDbContext.ExtraAndDiscounts.FirstOrDefault();
            return extraAndDiscount;
        }


        public int Update(ExtraAndDiscount extraAndDiscount)
        {
            ExtraAndDiscount oldExtraAndDiscount = GetExtraAndDiscount();
           
            oldExtraAndDiscount.Extra = extraAndDiscount.Extra;
            oldExtraAndDiscount.Discount = extraAndDiscount.Discount;
            int UpdateHoliday = applicationDbContext.SaveChanges();
            return UpdateHoliday;
        }




    }
}
