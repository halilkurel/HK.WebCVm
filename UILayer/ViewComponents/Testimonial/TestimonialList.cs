using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        private readonly ITestimonialService _estimonialService;

        public TestimonialList(ITestimonialService estimonialService)
        {
            _estimonialService = estimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _estimonialService.GetAll();
            return View(data);
        }
    }
}
