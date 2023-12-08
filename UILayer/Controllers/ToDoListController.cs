using AutoMapper;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DtoLayer.SkillDtos;
using DtoLayer.ToDoListDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _service;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoListService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddToDoList(string Contect)
        {
            // Gerekli doğrulama işlemlerini yapabilirsiniz.

            var createDto = new CreateToDoListDto
            {
                Contect = Contect,
                Status = true
            };

            var response = await _service.Create(createDto);

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validatorErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ViewComponent("ToDoListPanel"); // Hata durumunda aynı sayfaya dön
            }

            return RedirectToAction("Index","Dashboard"); // Ekleme başarılıysa, örneğin ana sayfaya yönlendirin
        }




    }
}
