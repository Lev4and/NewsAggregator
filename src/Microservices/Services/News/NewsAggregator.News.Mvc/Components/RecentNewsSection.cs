using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class RecentNewsSection : ViewComponent
    {
        private readonly IMediator _mediator;

        public RecentNewsSection(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken = default)
        {
            var newsListFilters = new GetNewsListFilters()
            {
                HasPublishedAt = true,
                PageSize = 10
            };

            var news = await _mediator.Send(new GetNewsListQuery(newsListFilters), cancellationToken);

            return View(news.Result.Items);
        }
    }
}
