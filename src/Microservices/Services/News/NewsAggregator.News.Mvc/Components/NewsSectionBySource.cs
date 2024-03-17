using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class NewsSectionBySource : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsSectionBySource(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var newsSource = await _mediator.Send(new GetNewsSourceByIdQuery(id), cancellationToken);

            var newsListFilters = new GetNewsListFilters()
            {
                NewsSourcesIds = [newsSource.Id],
                HasPublishedAt = null,
                PageSize = 10
            };

            var newsList = await _mediator.Send(new GetNewsListQuery(newsListFilters), cancellationToken);

            var result = new NewsSectionBySourceDto
            {
                News = newsList,
                Source = newsSource
            };

            return View(result);
        }
    }
}
