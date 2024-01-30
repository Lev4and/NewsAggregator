using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewsAggregator.News.Mvc.Controllers
{
    [Route("authors")]
    public class AuthorsController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "Authors")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id:guid:required}", Name = "Author")]
        public async Task<IActionResult> GetAuthorPageByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            return View("Author");
        }
    }
}
