using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Commands;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace NewsAggregator.News.Api.Areas.Parsing.Controllers
{
    [ApiController]
    [Area("parsing")]
    [Route("api/news/parsing/")]
    public class ParsingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParsingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(NewsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TestParseNewsAsync([Required][FromQuery(Name = "newsUrl")] string newsUrl,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ParseNewsCommand(newsUrl), cancellationToken));
        }

        [HttpPost]
        [Route("test")]
        [ProducesResponseType(typeof(NewsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TestParseNewsAsync([Required][FromBody] TestParseNewsDto dto,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new TestParseNewsCommand(dto.NewsUrl, dto.ParserOptions), 
                cancellationToken));
        }
    }
}
