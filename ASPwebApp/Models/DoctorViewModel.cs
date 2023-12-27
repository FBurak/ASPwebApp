using System.ComponentModel.DataAnnotations;

namespace ASPwebApp.Models
{
    public class DoctorModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string Username { get; set; }
        public string Major { get; set; }

        public List<WorkingDay> WorkingDays { get; set; }
        public class WorkingDay
        {
            public int Id { get; set; }
            public DayOfWeek DayOfWeek { get; set; } // Haftanın hangi günü
            public TimeSpan StartTime { get; set; }  // Çalışma başlangıç saati
            public TimeSpan EndTime { get; set; }    // Çalışma bitiş saati
        }
    }
    public class CreateDoctorModel
    {
        [Required(ErrorMessage = "Username is required/Kullanıcı adı gerekli")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters/ Kullanıcı adı maksimum 30 karakter uzunluğunda olmalı.")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        public string Major { get; set; }

        public List<WorkingDay> WorkingDays { get; set; }
        public class WorkingDay
        {
            public int Id { get; set; }
            public DayOfWeek DayOfWeek { get; set; } // Haftanın hangi günü
            public TimeSpan StartTime { get; set; }  // Çalışma başlangıç saati
            public TimeSpan EndTime { get; set; }    // Çalışma bitiş saati
        }
    }

    public class EditDoctorModel
    {
        [Required(ErrorMessage = "Username is required/Kullanıcı adı gerekli")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters/ Kullanıcı adı maksimum 30 karakter uzunluğunda olmalı.")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        public string Major { get; set; }

        public List<WorkingDay> WorkingDays { get; set; }
        public class WorkingDay
        {
            public int Id { get; set; }
            public DayOfWeek DayOfWeek { get; set; } // Haftanın hangi günü
            public TimeSpan StartTime { get; set; }  // Çalışma başlangıç saati
            public TimeSpan EndTime { get; set; }    // Çalışma bitiş saati
        }
    }
}
