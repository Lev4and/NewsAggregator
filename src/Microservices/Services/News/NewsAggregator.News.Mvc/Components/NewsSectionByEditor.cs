using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class NewsSectionByEditor : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewsSectionByEditor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var newsEditor = await _mediator.Send(new GetNewsEditorByIdQuery(id), cancellationToken);

            var newsListFilters = new GetNewsListFilters()
            {
                NewsEditorsIds = [newsEditor.Id],
                HasPublishedAt = null,
                PageSize = 10
            };

            var newsList = await _mediator.Send(new GetNewsListQuery(newsListFilters), cancellationToken);

            var result = new NewsSectionByEditorDto
            {
                News = newsList,
                Editor = newsEditor
            };

            return View(result);
        }
    }
}
