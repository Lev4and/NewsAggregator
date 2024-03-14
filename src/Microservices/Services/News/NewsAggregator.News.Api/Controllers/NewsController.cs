using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Domain.Entities;
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
    [Route("api/news/v{apiVersion:apiVersion}/")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<GetNewsListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsListByFiltersAsync([FromQuery] GetNewsListFilters filters,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsListDtoQuery(filters), cancellationToken));
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
        [Route("contains")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ContainsNewsByUrlAsync([Required][FromQuery(Name = "url")] string url,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ContainsNewsByUrlCommand(url), cancellationToken));
        }

        [HttpGet]
        [Route("editors")]
        [ProducesResponseType(typeof(ApiResponse<GetNewsEditorListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsEditorListByFiltersAsync([FromQuery] GetNewsEditorListFilters filters,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsEditorListQuery(filters), cancellationToken));
        }

        [HttpGet]
        [Route("editors/{id:guid:required}")]
        [ProducesResponseType(typeof(ApiResponse<NewsEditor>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsEditorByIdAsync([Required][FromRoute(Name = "id")] Guid id, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsEditorByIdQuery(id), cancellationToken));
        }

        [HttpGet]
        [Route("sources")]
        [ProducesResponseType(typeof(ApiResponse<GetNewsSourceListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewsSourceListByFiltersAsync([FromQuery] GetNewsSourceListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetNewsSourceListQuery(filters), cancellationToken));
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
