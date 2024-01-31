using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class FoundNewsUrlsMessageConsumer : IConsumer<FoundNewsUrls>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FoundNewsUrlsMessageConsumer> _logger;

        public FoundNewsUrlsMessageConsumer(IMediator mediator, ILogger<FoundNewsUrlsMessageConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<FoundNewsUrls> context)
        {
            var dictionary = await _mediator.Send(new ContainsNewsByUrlsCommand(context.Message.NewsUrls));

            var notContainedNews = dictionary.Where(pair => !pair.Value)
                .Select(pair => pair.Key)
                .ToList();

            _logger.LogInformation("Found {0} not contained news", notContainedNews.Count);

            foreach (var newsUrl in notContainedNews)
            {
                await _mediator.Publish(new NotContainedNews(newsUrl));
            }
        }
    }
}
