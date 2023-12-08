using EntityLayer.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel mod = new();
            mod.Name = values.Name;
            mod.Username = values.UserName;
            mod.Email = values.Email;
            mod.Surname = values.Surname;
            mod.PictureUrl = values.ImageUrl;
            return View(mod);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(model.Picture != null)
            {
                var resours = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Picture.FileName);
                var imagename = Guid.NewGuid()+extension;
                var savelocation = resours + "/wwwroot/Images/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await model.Picture.CopyToAsync(stream);
                values.ImageUrl = imagename;
            }
            values.Name= model.Name;
            values.Surname= model.Surname;
            values.Email= model.Email;
            var result = await _userManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
