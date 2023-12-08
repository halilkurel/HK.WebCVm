using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Navbar
{
    public class NavbarList : ViewComponent
    {
        private readonly IHeaderService _headerservice;

        public NavbarList(IHeaderService headerservice)
        {
            _headerservice = headerservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _headerservice.GetAll();
            return View(data);
        }
    }
}
