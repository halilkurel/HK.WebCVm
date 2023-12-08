namespace UILayer.Models
{
    public class UserEditViewModel
    {
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? PictureUrl { get; set; }
        public IFormFile Picture { get; set; }
    }
}
