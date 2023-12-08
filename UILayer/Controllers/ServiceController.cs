using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DtoLayer.ServicesDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServicesService _ServiceService;

        public ServiceController(IServicesService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _ServiceService.GetAll();
            return View(response);
        }

        public IActionResult AddService()
        {
            return View(new ServiceCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceCreateDto dto)
        {
            var response = await _ServiceService.Create(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validatorErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public async Task<IActionResult> UpdateService(int id)
        {

            var response = await _ServiceService.GetById<ServiceUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceUpdateDto dto)
        {
            var response = await _ServiceService.Update(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validatorErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var response = await _ServiceService.Remove(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return RedirectToAction("Index");
        }

        public IActionResult NotFound(int id)
        {
            return View();
        }

    }
}
