using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Main
{
    public class MainList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
