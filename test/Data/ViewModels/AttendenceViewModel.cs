using Microsoft.AspNetCore.Mvc;
using System;

namespace test.ViewModel
{
    public class AttendenceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        [Remote(action: "TestTimeIfUnique", controller: "Attendance", AdditionalFields = "CheckOut,CheckIn"
            , ErrorMessage = "error")]
        public TimeSpan CheckOut { get; set; }

    }
}
