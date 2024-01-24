using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class NotParsedNewsConsumer : IConsumer<NotParsedNews>
    {
        private readonly IMediator _mediator;

        public NotParsedNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NotParsedNews> context)
        {
            await _mediator.Send(new AddNewsParseErrorCommand(context.Message.NewsUrl, context.Message.CreatedAt, 
                context.Message.Exception));
        }
    }
}
