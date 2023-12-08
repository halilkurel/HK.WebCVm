using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using DtoLayer.FooterDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class FooterController : Controller
    {
        private readonly IFooterService _FooterService;

        public FooterController(IFooterService FooterService)
        {
            _FooterService = FooterService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _FooterService.GetAll();
            return View(response);
        }




        public async Task<IActionResult> UpdateFooter(int id)
        {

            var response = await _FooterService.GetById<FooterUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooter(FooterUpdateDto dto)
        {
            var response = await _FooterService.Update(dto);
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
    }
}
