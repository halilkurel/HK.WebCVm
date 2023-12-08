using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        private readonly IContactService _contactService;

        public MessageList(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _contactService.GetAll();
            var list = data.OrderByDescending(p => p.Id).Take(4).ToList();
            return View(data);
        }
    }
}
