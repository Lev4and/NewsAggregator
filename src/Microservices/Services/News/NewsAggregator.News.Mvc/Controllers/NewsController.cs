using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
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
        public async Task<IActionResult> Index([FromQuery] GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            var dto = await _mediator.Send(new GetNewsListDtoQuery(filters), cancellationToken);

            return View(dto);
        }

        [HttpGet("{id:guid:required}", Name = "News")]
        public async Task<IActionResult> GetNewsPageByIdAsync([Required][FromRoute(Name = "id")] Guid id, 
            CancellationToken cancellationToken = default)
        {
            var news = await _mediator.Send(new GetNewsByIdQuery(id), cancellationToken);

            await _mediator.Publish(new NewsViewed(id, HttpContext.GetConnectionIpAddress()));

            return View("News", news);
        }

        [HttpPost]
        [Route("{newsId:guid:required}/sendNewsReaction")]
        public async Task<IActionResult> SendNewsReactionAsync([Required][FromRoute(Name = "newsId")] Guid newsId,
            [Required][FromQuery(Name = "reactionId")] Guid reactionId, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(new NewsReacted(newsId, reactionId, HttpContext.GetConnectionIpAddress()),
                cancellationToken);

            return Ok();
        }
    }
}
