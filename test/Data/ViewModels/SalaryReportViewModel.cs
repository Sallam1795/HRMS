using System;

namespace test.Data.ViewModels
{
    public class SalaryReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public int AttendanceDays { get; set; }
        public int AbsentDays { get; set; }
        public double OverTimeHours { get; set; }
        public double DiscountHours { get; set; }
        public double Extra { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public DateTime DateSearched { get; set; }
    }
}
