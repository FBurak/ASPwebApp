using System.ComponentModel.DataAnnotations.Schema;

namespace ASPwebApp.Entities
{
    [Table("WorkingDays")]
    public class WorkingDay
    {
        public Doctor DoctorId { get; set; } 
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public bool Available { get; set; }
    }
}
