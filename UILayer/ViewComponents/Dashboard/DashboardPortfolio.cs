using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Dashboard
{
    public class DashboardPortfolio : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IHeaderService _headerService;

        public DashboardPortfolio(IPortfolioService portfolioService, IHeaderService headerService)
        {
            _portfolioService = portfolioService;
            _headerService = headerService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dataHeadaer= await _headerService.GetAll();
            ViewBag.v1= dataHeadaer.FirstOrDefault().Image;
            var data = await _portfolioService.GetAll();
            return View(data);
        }
    }
}
