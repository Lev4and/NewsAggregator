using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class NewsReactions : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsReactions(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid newsId, 
            CancellationToken cancellationToken = default)
        {
            var reactions = await _mediator.Send(new GetNewsReactionsQuery(newsId), cancellationToken);

            return View(reactions);
        }
    }
}
