using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
