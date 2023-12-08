using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.Dashboard
{
    public class Last5Projects :ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public Last5Projects(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allProjects = await _portfolioService.GetAll();

            // Son 5 projeyi almak için, projeleri tarih veya başka bir ölçüt üzerinde sıralayabilirsiniz.
            var last5Projects = allProjects.OrderByDescending(p => p.ReleaseDate).Take(6).ToList();

            return View(last5Projects);
        }

    }
}
