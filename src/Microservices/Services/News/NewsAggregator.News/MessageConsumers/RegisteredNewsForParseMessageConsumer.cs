using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisteredNewsForParseMessageConsumer : IConsumer<RegisteredNewsForParse>
    {
        private readonly IMediator _mediator;

        public RegisteredNewsForParseMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<RegisteredNewsForParse> context)
        {
            try
            {
                var news = await _mediator.Send(new ParseNewsCommand(context.Message.NewsUrl));

                await _mediator.Publish(new ParsedNews(news));
            }
            catch (HttpRequestException ex)
            {
                await _mediator.Publish(new ThrowedHttpRequestExceptionWhenParseNews(context.Message.NewsUrl,
                    ex.Message, DateTime.UtcNow));
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ThrowedExceptionWhenParseNews(context.Message.NewsUrl,
                    ex.Message, DateTime.UtcNow));
            }
        }
    }
}
