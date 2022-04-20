using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class ExtraAndDiscount
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Must Provide A Extra")]

        public double Extra { get; set; }
        [Required(ErrorMessage = "You Must Provide A Extra")]

        public double Discount { get; set; }
    }
}
