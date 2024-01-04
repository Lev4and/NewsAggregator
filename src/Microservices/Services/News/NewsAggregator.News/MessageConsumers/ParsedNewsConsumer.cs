using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class ParsedNewsConsumer : IConsumer<ParsedNews>
    {
        private readonly IMediator _mediator;

        public ParsedNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ParsedNews> context)
        {
            await _mediator.Send(new AddNewsCommand(context.Message.News));
        }
    }
}
