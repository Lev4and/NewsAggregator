using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.News.Mvc.Controllers
{
    [Route("sources")]
    public class SourcesController : Controller
    {
        private readonly IMediator _mediator;

        public SourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "Sources")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var sources = await _mediator.Send(new GetNewsSourcesQuery(), cancellationToken);

            return View(sources);
        }

        [HttpGet("{id:guid:required}", Name = "Source")]
        public async Task<IActionResult> GetSourcePageByIdAsync([Required][FromRoute(Name = "id")] Guid id, 
            CancellationToken cancellationToken = default)
        {
            var source = await _mediator.Send(new GetNewsSourceByIdQuery(id), cancellationToken);

            return View("Source", source);
        }
    }
}
