using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Infrastructure.Web.Http;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;
using System.ComponentModel.DataAnnotations;
using System.Net;

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
        [ProducesResponseType(typeof(ApiResponse<Entities.News>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsByIdQuery(id), cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<Entities.News>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsByUrlAsync([Required][FromQuery(Name = "url")] string url,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsByUrlQuery(url), cancellationToken));
        }

        [HttpGet]
        [Route("contains")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ContainsNewsByUrlAsync([Required][FromQuery(Name = "url")] string url,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ContainsNewsByUrlCommand(url), cancellationToken));
        }

        [HttpGet]
        [Route("sources")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<NewsSource>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsSourcesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsSourcesQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("sources/{id:guid:required}")]
        [ProducesResponseType(typeof(ApiResponse<NewsSource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsSourceByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsSourceByIdQuery(id), cancellationToken));
        }
    }
}
