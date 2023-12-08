using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _TestimonialService.GetAll();
            return View(response);
        }

        public IActionResult AddTestimonial()
        {
            return View(new TestimonialCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialCreateDto dto)
        {
            var response = await _TestimonialService.Create(dto);
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

        public async Task<IActionResult> UpdateTestimonial(int id)
        {

            var response = await _TestimonialService.GetById<TestimonialUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateDto dto)
        {
            var response = await _TestimonialService.Update(dto);
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

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var response = await _TestimonialService.Remove(id);
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
