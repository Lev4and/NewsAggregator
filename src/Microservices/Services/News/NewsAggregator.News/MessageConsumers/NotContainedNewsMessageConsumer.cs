using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class NotContainedNewsMessageConsumer : IConsumer<NotContainedNews>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotContainedNewsMessageConsumer> _logger;

        public NotContainedNewsMessageConsumer(IMediator mediator, ILogger<NotContainedNewsMessageConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NotContainedNews> context)
        {
            try
            {
                var news = await _mediator.Send(new ParseNewsCommand(context.Message.NewsUrl));

                _logger.LogInformation("Parsed news {0}", news.Url);

                await _mediator.Publish(new ParsedNews(news));
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred when parse news {0}. Description: {1}", context.Message.NewsUrl, ex.Message);

                await _mediator.Publish(new NotParsedNews(context.Message.NewsUrl, ex.Message, DateTime.UtcNow));
            }
        }
    }
}
