using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using DtoLayer.AboutDtos;
using DtoLayer.HeaderDtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _AboutService.GetAll();
            return View(response);
        }


        

        public async Task<IActionResult> UpdateAbout(int id)
        {

            var response = await _AboutService.GetById<AboutUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutUpdateDto dto)
        {
            var response = await _AboutService.Update(dto);
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
