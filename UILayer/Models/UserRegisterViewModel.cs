using EntityLayer.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace UILayer.Models
{
    public class UserRegisterViewModel
    {


        public string? UserName { get; set; }
        public string? Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string? ConfirmPassword { get; set; }
        public string? Mail { get; set; }
    }
}
