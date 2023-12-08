using System.ComponentModel.DataAnnotations;

namespace UILayer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adınızı giriniz")]
        public string? Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz")]
        public string? Password { get; set; }

    }
}
