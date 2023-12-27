using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPwebApp.Entities
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [Required]
        public Guid DoctorId { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        public string Major { get; set; }
    }
}
