using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Entities = NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.Api.Controllers
{
    [ApiController]
    [Route("api/news/")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:guid:required}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<Entities.News>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsByIdQuery(id), cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<Entities.News>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsByUrlAsync([Required][FromQuery(Name = "url")] string url,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsByUrlQuery(url), cancellationToken));
        }

        [HttpGet]
        [Route("check")]
        [ProducesResponseType(typeof(IReadOnlyCollection<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckNewsOnExistsByUrlAsync([Required][FromQuery(Name = "url")] string url,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new CheckNewsOnExistsByUrlCommand(url), cancellationToken));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewsAsync([Required][FromBody] NewsDto news, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new AddNewsCommand(news), cancellationToken));
        }

        [HttpGet]
        [Route("sources")]
        [ProducesResponseType(typeof(IReadOnlyCollection<NewsSource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsSourcesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsSourcesQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("sources/{id:guid:required}")]
        [ProducesResponseType(typeof(NewsSource), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsSourceByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsSourceByIdQuery(id), cancellationToken));
        }

        [HttpPost]
        [Route("sources")]
        [ProducesResponseType(typeof(IReadOnlyCollection<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewsSourceAsync([Required][FromBody] NewsSource newsSource,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new AddNewsSourceCommand(newsSource), cancellationToken));
        }

        [HttpPut]
        [Route("sources")]
        [ProducesResponseType(typeof(IReadOnlyCollection<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateNewsSourceAsync([Required][FromBody] NewsSource newsSource,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new UpdateNewsSourceCommand(newsSource), cancellationToken));
        }

        [HttpDelete]
        [Route("sources/{id:guid:required}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<NewsSourceDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveNewsSourceByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new RemoveNewsSourceByIdCommand(id), cancellationToken));
        }
    }
}
