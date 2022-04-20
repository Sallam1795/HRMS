using System;
using System.ComponentModel.DataAnnotations;

namespace test.Data.Validate
{
    public class ValidateDateAttribute:RangeAttribute
    {
           public ValidateDateAttribute()
           : base(typeof(DateTime),
           DateTime.Now.AddYears(-60).ToString(),
           DateTime.Now.AddYears(-20).ToString())
        { }
    }
}
