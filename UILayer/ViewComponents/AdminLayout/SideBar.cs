using EntityLayer.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.AdminLayout
{
    public class SideBar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public SideBar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = value.Name+" "+value.Surname;
            ViewBag.Image = value.ImageUrl;
            return View();
        }
    }
}
