using System.ComponentModel.DataAnnotations;

namespace ASPwebApp.Entities
{
    public class Makeapm
    {
        [Key]
        public int MakeId { get; set; }
        public Guid Id { get; set; }
        public User User { get; set; } = null!;

        public int AppId { get; set; }
        public Appointment Appointment { get; set; } = null!;



        public DateTime AppointmentMakeTime { get; set; }
    }
}
