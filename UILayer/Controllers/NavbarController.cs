using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using DtoLayer.HeaderDtos;
using DtoLayer.SkillDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    [Authorize]
    public class NavbarController : Controller
    {
        private readonly IHeaderService _NavbarService;

        public NavbarController(IHeaderService NavbarService)
        {
            _NavbarService = NavbarService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _NavbarService.GetAll();
            return View(response);
        }




        public async Task<IActionResult> UpdateNavbar(int id)
        {

            var response = await _NavbarService.GetById<HeaderUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNavbar(HeaderUpdateDto dto)
        {
            var response = await _NavbarService.Update(dto);
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
