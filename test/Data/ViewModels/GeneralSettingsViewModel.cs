using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Data.ViewModels
{
    public class GeneralSettingsViewModel
    {

        [DataType(DataType.Text)]
        [Range(minimum: 1, maximum: 10, ErrorMessage = "Most Be Between 1 And 10")]
        public double Extra { get; set; }

        [Range(minimum: 1, maximum: 10, ErrorMessage = "Most Be Between 1 And 10")]
        public double Discount { get; set; }

        [Required(ErrorMessage = "error")]
        public List<WeeklyHoliday> weeklyHolidays { get; set; }

    }
}
