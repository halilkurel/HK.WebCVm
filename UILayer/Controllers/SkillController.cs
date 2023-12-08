using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DtoLayer.SkillDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _SkillService;

        public SkillController(ISkillService SkillService)
        {
            _SkillService = SkillService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _SkillService.GetAll();
            return View(response);
        }

        public IActionResult AddSkill()
        {
            return View(new SkillCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillCreateDto dto)
        {
            var response = await _SkillService.Create(dto);
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

        public async Task<IActionResult> UpdateSkill(int id)
        {

            var response = await _SkillService.GetById<SkillUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(SkillUpdateDto dto)
        {
            var response = await _SkillService.Update(dto);
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

        public async Task<IActionResult> DeleteSkill(int id)
        {
            var response = await _SkillService.Remove(id);
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
