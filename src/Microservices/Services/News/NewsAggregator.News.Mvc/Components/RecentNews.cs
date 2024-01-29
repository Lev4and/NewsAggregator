using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class RecentNews : ViewComponent
    {
        private readonly IMediator _mediator;

        public RecentNews(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await _mediator.Send(new GetRecentNewsQuery());

            return View(news);
        }
    }
}
