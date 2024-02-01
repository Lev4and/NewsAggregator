using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class CarouselRecentNews : ViewComponent
    {
        private readonly IMediator _mediator;

        public CarouselRecentNews(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 10, CancellationToken cancellationToken = default)
        {
            var news = await _mediator.Send(new GetRecentNewsQuery(count, true, true), cancellationToken);

            return View(news);
        }
    }
}
