using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class ParsedNewsMessageConsumer : IConsumer<ParsedNews>
    {
        private readonly IMediator _mediator;

        public ParsedNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ParsedNews> context)
        {
            await _mediator.Send(new AddNewsCommand(context.Message.News));
        }
    }
}
