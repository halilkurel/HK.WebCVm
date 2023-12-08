using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class MessageController : Controller
    {
        private readonly IContactService _contactService;

        public MessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _contactService.GetAll();

            // Verileri tarih sırasına göre en sonuncusundan en öncekine doğru sırala
            data = data.Where(x => x.Status == "False").OrderByDescending(item => item.Date).ToList();

            return View(data);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var response = await _contactService.Remove(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return RedirectToAction("Index");
        }
    }
}
