using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _subscribeService.GetAll();
            return View(response);
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var response = await _subscribeService.Remove(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return RedirectToAction("Index");
        }

    }
}
