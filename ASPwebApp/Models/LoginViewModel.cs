using System.ComponentModel.DataAnnotations;

namespace ASPwebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username is required/Kullanıcı adı gerekli")]
        [StringLength(30,ErrorMessage ="Username can be max 30 characters/ Kullanıcı adı maksimum 30 karakter uzunluğunda olmalı.")]
        public string Username { get; set; }
        

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required/ Şifre gerekli.")]
        [MinLength(6,ErrorMessage = "Password can be min 6 characters/ Şifre minimum 6 karakter uzunluğunda olmalı.")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 characters/ Şifre maksimum 16 karakter uzunluğunda olmalı.")]
        public string Password { get; set; }

    }
}
