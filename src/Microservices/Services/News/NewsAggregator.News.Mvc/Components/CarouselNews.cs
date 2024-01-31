using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.Mvc.Components
{
    public class CarouselNews : ViewComponent
    {
        private readonly IMediator _mediator;

        public CarouselNews(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 10)
        {
            var news = await _mediator.Send(new GetRecentNewsQuery(count));

            return View(news);
        }
    }
}
