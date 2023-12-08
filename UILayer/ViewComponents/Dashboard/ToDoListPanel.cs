using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        private readonly IToDoListService _service;

        public ToDoListPanel(IToDoListService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _service.GetAll();
            var result = data.OrderByDescending(x => x.Id).Take(10).ToList();
            return View(result);
        }
    }
}
