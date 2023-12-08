using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Education
{
    public class EducationList  :ViewComponent
    {
        private readonly IEducationService _educationService;

        public EducationList(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _educationService.GetAll();
            return View(data);
        }
    }
}