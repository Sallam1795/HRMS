using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public TimeSpan OverTime { get; set; }
        public TimeSpan DiscountTime { get; set; }
        public int Absent { get; set; }
        public int Attend { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
