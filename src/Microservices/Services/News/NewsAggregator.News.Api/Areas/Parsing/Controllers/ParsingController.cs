using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
