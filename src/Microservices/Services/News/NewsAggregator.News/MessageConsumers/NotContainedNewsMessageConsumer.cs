using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class NotContainedNewsMessageConsumer : IConsumer<NotContainedNews>
    {
        private readonly IMediator _mediator;

        public NotContainedNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NotContainedNews> context)
        {
            try
            {
                var news = await _mediator.Send(new ParseNewsCommand(context.Message.NewsUrl));

                await _mediator.Publish(new ParsedNews(news));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new NotParsedNews(context.Message.NewsUrl, ex.Message, DateTime.UtcNow));
            }
        }
    }
}
