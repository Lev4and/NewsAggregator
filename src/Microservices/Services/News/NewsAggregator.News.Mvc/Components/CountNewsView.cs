using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class CountNewsView : ViewComponent
    {
        private readonly IMediator _mediator;

        public CountNewsView(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid newsId, CancellationToken cancellationToken = default)
        {
            var count = await _mediator.Send(new GetCountNewsViewByNewsIdQuery(newsId), cancellationToken);

            return View(count);
        }
    }
}
