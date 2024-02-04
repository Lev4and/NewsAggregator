using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;
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
        public async Task<IActionResult> Index([FromQuery] GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            var dto = await _mediator.Send(new GetNewsEditorListQuery(filters), cancellationToken);

            return View(dto);
        }

        [HttpGet("{id:guid:required}", Name = "Author")]
        public async Task<IActionResult> GetAuthorPageByIdAsync([Required][FromRoute(Name = "id")] Guid id,
            CancellationToken cancellationToken = default)
        {
            var editor = await _mediator.Send(new GetNewsEditorByIdQuery(id), cancellationToken);

            return View("Author", editor);
        }
    }
}
