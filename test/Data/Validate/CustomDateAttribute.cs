using System;
using System.ComponentModel.DataAnnotations;

namespace test.Data.Validate
{
    public class CustomDateAttribute : RangeAttribute
    {
        //protected override ValidationResult IsValid(object date, ValidationContext validationContext)
        //{
        //    DateTime _EmpAge = Convert.ToDateTime(date);
        //    if (DateTime.Now.Year - _EmpAge.Year < 21)
        //        return new ValidationResult("Cant be Younger Than 21 years");

        //    return ValidationResult.Success;
        //}
        //public override bool IsValid(object value)
        //{
        //    DateTime _EmpAge = Convert.ToDateTime(value);
        //    return (DateTime.Now.Year - _EmpAge.Year) < 21;
        //}
        public CustomDateAttribute()
           : base(typeof(DateTime),
           DateTime.Now.AddYears(-60).ToString(),
           DateTime.Now.AddYears(-20).ToString())
        { }
    }
}
