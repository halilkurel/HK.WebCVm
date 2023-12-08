using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        private readonly IServicesService _servicesService;

        public ServiceList(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _servicesService.GetAll();
            return View(data);
        }
    }
}
