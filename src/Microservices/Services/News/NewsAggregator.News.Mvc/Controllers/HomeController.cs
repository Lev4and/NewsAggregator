using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.Mvc.Models;
using System.Diagnostics;

namespace NewsAggregator.News.Mvc.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "Main")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
