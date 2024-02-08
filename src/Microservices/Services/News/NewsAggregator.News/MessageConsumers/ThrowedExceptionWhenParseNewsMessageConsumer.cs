using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class ThrowedExceptionWhenParseNewsMessageConsumer : IConsumer<ThrowedExceptionWhenParseNews>
    {
        private readonly IMediator _mediator;

        public ThrowedExceptionWhenParseNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ThrowedExceptionWhenParseNews> context)
        {
            await _mediator.Send(new AddNewsParseErrorCommand(context.Message.NewsUrl, context.Message.Message, 
                context.Message.CreatedAt));

            await _mediator.Send(new RemoveNewsForParseCommand(context.Message.NewsUrl));
        }
    }
}
