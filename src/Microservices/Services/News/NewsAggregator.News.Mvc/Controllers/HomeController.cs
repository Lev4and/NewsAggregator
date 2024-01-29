using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.Mvc.Models;
using NewsAggregator.News.UseCases.Queries;
using System.Diagnostics;

namespace NewsAggregator.News.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var news = await _mediator.Send(new GetRecentNewsExtendedQuery(), cancellationToken);

            return View(news);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
