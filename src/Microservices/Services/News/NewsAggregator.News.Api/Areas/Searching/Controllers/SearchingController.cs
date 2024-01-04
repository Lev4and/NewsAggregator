using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Infrastructure.Web.Http;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Commands;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace NewsAggregator.News.Api.Areas.Searching.Controllers
{
    [ApiController]
    [Area("searching")]
    [Route("api/news/searching/")]
    public class SearchingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<string>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SearchNewsAsync([Required][FromQuery(Name = "siteUrl")] string siteUrl,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new SearchNewsCommand(siteUrl), cancellationToken));
        }

        [HttpPost]
        [Route("test")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<string>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TestSearchNewsAsync([Required][FromBody] TestSearchNewsDto dto, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new TestSearchNewsCommand(dto.NewsSiteUrl, dto.NewsUrlXPath), 
                cancellationToken));
        }
    }
}
