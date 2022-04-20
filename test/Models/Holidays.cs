using System;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Holidays
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Must Provide A Name Of Day")]

        public string Name { get; set; }
        [Required(ErrorMessage = "You Must Provide A Date Of Day")]

        public DateTime Date { get; set; }

    }
}
