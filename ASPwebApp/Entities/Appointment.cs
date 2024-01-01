using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPwebApp.Entities
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public int AppId { get; set; } 
        public string? Title { get; set; }
    }
}
