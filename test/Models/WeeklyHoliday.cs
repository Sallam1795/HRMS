using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class WeeklyHoliday
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Must Provide A Name Of Day")]

        public string Name{ get; set; }
        [Required(ErrorMessage = "You Must Choose Day")]

        public bool IsDayOff{ get; set; }

    }
}
