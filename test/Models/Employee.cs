using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Data.Validate;

namespace test.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You Must Provide A Name"), MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Provide A Address")]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email Is Not Valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Provide A Start Work Date")]
        [DataType(DataType.Date)]
        public DateTime StartWork { get; set; }
        [Required(ErrorMessage = "You Must Provide A Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-5]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Not A Valid Phone Number")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "You Must Provide A Date Of Birth")]
        //[DataType(DataType.Date)]
        //[CustomDate(ErrorMessage = "Cant be younger than 21 years")]
        //[ValidateDate]
        //[CustomDate]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "You Must Provide A Gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "You Must Provide A Start Duration")]
        [DataType(DataType.Time)]
        public TimeSpan StartDuration { get; set; }

        [Required(ErrorMessage = "You Must Provide A End Duration")]
        [DataType(DataType.Time)]
        public TimeSpan EndDuration { get; set; }

        [Required(ErrorMessage = "You Must Provide A Salary")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Salary Must Be Numeric")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "You Must Provide A National Id")]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "National Id Must Be 14 & Number Only")]
        public string nationalID { get; set; }
        [Required(ErrorMessage = "You Must Provide A Nationality")]

        public string nationality { get; set; }

        public virtual List<Attendance> Attendances { get; set; }
        public virtual List<Archiev> Archievs { get; set; }

        public Employee()
        {
            Attendances = new List<Attendance>();
            Archievs = new List<Archiev>();
        }
    }
}
