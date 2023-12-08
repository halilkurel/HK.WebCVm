using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UILayer.Controllers;

namespace UILayer.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly ISubscribeService _subscribeService;
        private readonly IAboutService _aboutService;

        public FeatureStatistics(IContactService contactService, ISubscribeService subscribeService, IAboutService aboutService)
        {
            _contactService = contactService;
            _subscribeService = subscribeService;
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dataContact = await _contactService.GetAll();
            var dataSubscribe = await _subscribeService.GetAll();
            var dataAbout = await _aboutService.GetAll();
            ViewBag.Contact = dataContact.Count;
            ViewBag.Subscribe = dataSubscribe.Count;
            ViewBag.Client = dataAbout.FirstOrDefault()?.Client;
            return View();
        }
    }
}
