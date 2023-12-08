using BussinessLayer.Interfaces;
using EntityLayer.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.AdminLayout
{
    public class NavbarAdmin : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISubscribeService _subscribeService;

        public NavbarAdmin(UserManager<AppUser> userManager, ISubscribeService subscribeService)
        {
            _userManager = userManager;
            _subscribeService = subscribeService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var subscribeListDtos = await _subscribeService.GetAll();
            var result = subscribeListDtos.OrderByDescending(x => x.Id).Take(4).ToList();
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = value.Name + " " + value.Surname;
            ViewBag.Image = value.ImageUrl;
            return View(result);
        }
    }
}
