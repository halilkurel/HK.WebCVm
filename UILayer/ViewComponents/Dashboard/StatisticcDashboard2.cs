using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Dashboard
{
    public class StatisticcDashboard2 : ViewComponent
    {
        private readonly ISkillService _skillService;
        private readonly IServicesService _servicesService;
        private readonly IContactService _contactService;
        private readonly IAboutService _aboutService;

        public StatisticcDashboard2(ISkillService skillService, IServicesService servicesService, IContactService contactService, IAboutService aboutService)
        {
            _skillService = skillService;
            _servicesService = servicesService;
            _contactService = contactService;
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skill = await _skillService.GetAll();
            var service = await _servicesService.GetAll();
            var client = await _aboutService.GetAll();
            ViewBag.Skill = skill.Count();
            ViewBag.Service = service.Count();
            ViewBag.Client = client.FirstOrDefault()?.Client;
            return View();
        }
    }
}
