using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class NewsSectionByTagId : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsSectionByTagId(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var newsTag = await _mediator.Send(new GetNewsTagByIdQuery(id), cancellationToken);

            var newsListFilters = new GetNewsListFilters()
            {
                NewsTagsIds = [newsTag.Id],
                HasPublishedAt = null,
                PageSize = 10
            };

            var newsList = await _mediator.Send(new GetNewsListQuery(newsListFilters), cancellationToken);

            var result = new NewsSectionByTagDto
            {
                News = newsList,
                Tag = newsTag
            };

            return View(result);
        }
    }
}
