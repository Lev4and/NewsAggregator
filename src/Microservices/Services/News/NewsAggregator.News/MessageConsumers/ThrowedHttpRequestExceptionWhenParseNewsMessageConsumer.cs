using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class ThrowedHttpRequestExceptionWhenParseNewsMessageConsumer : IConsumer<ThrowedHttpRequestExceptionWhenParseNews>
    {
        private readonly IMediator _mediator;

        public ThrowedHttpRequestExceptionWhenParseNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ThrowedHttpRequestExceptionWhenParseNews> context)
        {
            await _mediator.Send(new AddNewsParseNetworkErrorCommand(context.Message.NewsUrl, context.Message.Message,
                context.Message.CreatedAt));

            await _mediator.Send(new RemoveNewsForParseCommand(context.Message.NewsUrl));
        }
    }
}
