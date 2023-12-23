using System.ComponentModel.DataAnnotations;

namespace ASPwebApp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string Username { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public String Role { get; set; } = "user";
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Username is required/Kullanıcı adı gerekli")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters/ Kullanıcı adı maksimum 30 karakter uzunluğunda olmalı.")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required/ Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Password can be min 6 characters/ Şifre minimum 6 karakter uzunluğunda olmalı.")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 characters/ Şifre maksimum 16 karakter uzunluğunda olmalı.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Re-Password is required/ Şifre gerekli.")]
        [MinLength(6, ErrorMessage = "Re-Password can be min 6 characters/ Şifre minimum 6 karakter uzunluğunda olmalı.")]
        [MaxLength(16, ErrorMessage = "Re-Password can be max 16 characters/ Şifre maksimum 16 karakter uzunluğunda olmalı.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }

        [Required]
        [StringLength(50)]
        public String Role { get; set; } = "user";
    }
}
