using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class NewsSectionByTagName : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsSectionByTagName(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name, 
            CancellationToken cancellationToken = default)
        {
            var newsTag = await _mediator.Send(new GetNewsTagByNameQuery(name), cancellationToken);

            var newsListFilters = new GetNewsListFilters()
            {
                NewsTagsIds = [ newsTag.Id ],
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
