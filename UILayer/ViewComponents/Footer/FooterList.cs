using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Footer
{
    public class FooterList : ViewComponent
    {
        private readonly IFooterService _footerservice;

        public FooterList(IFooterService footerservice)
        {
            _footerservice = footerservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _footerservice.GetAll();
            return View(data);
        }
    }
}
