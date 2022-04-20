using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using test.Models;

namespace test.Data.Validate
{
    public class TestTimeAttribute:ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    TimeSpan dateTime=;
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    Attendance attendance = context.Attendances.FirstOrDefault(s => s.CheckIn==dateTime);
        //}
    }
}
