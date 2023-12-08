using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using Common.ResponseObject;
using DtoLayer.EducationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _educationService.GetAll();
            return View(data);
        }

        public IActionResult AddEducation()
        {
            return View(new EducationCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationCreateDto dto)
        {
            var response = await _educationService.Create(dto);
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

        public async Task<IActionResult> UpdateEducation(int id)
        {

            var response = await _educationService.GetById<EducationUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEducation(EducationUpdateDto dto)
        {
            var response = await _educationService.Update(dto);
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

        public async Task<IActionResult> DeleteEducation(int id)
        {
            var response = await _educationService.Remove(id);
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
