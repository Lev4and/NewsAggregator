using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class FoundNewsUrlsMessageConsumer : IConsumer<FoundNewsUrls>
    {
        private readonly IMediator _mediator;

        public FoundNewsUrlsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNewsUrls> context)
        {
            var dictionary = await _mediator.Send(new ContainsNewsByUrlsCommand(context.Message.NewsUrls));

            var notContainedNews = dictionary.Where(pair => !pair.Value)
                .Select(pair => pair.Key)
                .ToList();

            foreach (var newsUrl in notContainedNews)
            {
                await _mediator.Publish(new NotContainedNews(newsUrl));
            }
        }
    }
}
