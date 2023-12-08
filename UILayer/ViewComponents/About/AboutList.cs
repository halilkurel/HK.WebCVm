using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        private readonly IAboutService _aboutservice;

        public AboutList(IAboutService aboutservice)
        {
            _aboutservice = aboutservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _aboutservice.GetAll();
            return View(data);
        }
    }
}
