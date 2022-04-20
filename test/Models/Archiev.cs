using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Archiev
    {
        public int Id { get; set; }
        public int AbsentArch { get; set; }
        public int AttendanceArch { get; set; }
        public TimeSpan OverTimeArch { get; set; }
        public TimeSpan DiscountTimeArch { get; set; }
        public DateTime Date { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
