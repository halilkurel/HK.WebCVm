using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DtoLayer.PortfolioDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _PortfolioService;

        public PortfolioController(IPortfolioService PortfolioService)
        {
            _PortfolioService = PortfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _PortfolioService.GetAll();
            return View(response);
        }

        public IActionResult AddPortfolio()
        {
            return View(new PortfolioCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioCreateDto dto)
        {
            var response = await _PortfolioService.Create(dto);
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

        public async Task<IActionResult> UpdatePortfolio(int id)
        {

            var response = await _PortfolioService.GetById<PortfolioUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateDto dto)
        {
            var response = await _PortfolioService.Update(dto);
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

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var response = await _PortfolioService.Remove(id);
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
