using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class FoundNotExistedNewsMessageConsumer : IConsumer<FoundNotExistedNews>
    {
        private readonly IMediator _mediator;

        public FoundNotExistedNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNotExistedNews> context)
        {
            await _mediator.Send(new RegisterNewsForParseCommand(context.Message.NewsUrl));

            await _mediator.Publish(new RegisteredNewsForParse(context.Message.NewsUrl));
        }
    }
}
