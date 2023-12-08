using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using DtoLayer.ContactDtos;
using DtoLayer.HeaderDtos;
using DtoLayer.SubscribeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IContactService _contactService;
        private readonly IFooterService _footerService;

        public DefaultController(ISubscribeService subscribeService, IContactService contactService, IFooterService footerService)
        {
            _subscribeService = subscribeService;
            _contactService = contactService;
            _footerService = footerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string mail)
        {
            if (!string.IsNullOrEmpty(mail))
            {
                // E-posta aboneliği oluştur
                await _subscribeService.Create(new SubscribeCreateDto { Mail = mail });
            }

            // Abone olduktan sonra başka bir sayfaya yönlendirilebilirsiniz
            return RedirectToAction("Index");
        }

        public IActionResult ContactPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactCreateDto model)
        {
            if (ModelState.IsValid)
            {
                // Gelen verileri ContactService aracılığıyla işleyin ve veritabanına kaydedin
                await _contactService.Create(model);

                // Başka bir sayfaya yönlendirme yapabilirsiniz
                return RedirectToAction("Index");
            }

            // Hata durumunda aynı sayfaya dön
            return View("ContactPartial");
        }

    }
}

