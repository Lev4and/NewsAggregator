using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.News.Mvc.Controllers
{
    [Route("news")]
    public class NewsController : Controller
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "NewsList")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var news = await _mediator.Send(new GetRecentNewsQuery(100), cancellationToken);

            return View(news);
        }

        [HttpGet("{id:guid:required}", Name = "News")]
        public async Task<IActionResult> GetNewsPageByIdAsync([Required][FromRoute(Name = "id")] Guid id, 
            CancellationToken cancellationToken = default)
        {
            var news = await _mediator.Send(new GetNewsByIdQuery(id), cancellationToken);

            return View("News", news);
        }
    }
}
