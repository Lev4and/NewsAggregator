using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class FoundNewsConsumer : IConsumer<FoundNews>
    {
        private readonly IMediator _mediator;

        public FoundNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNews> context)
        {
            var exists = await _mediator.Send(new CheckNewsOnExistsByUrlCommand(context.Message.NewsUrl));

            if (!exists)
            {
                await _mediator.Publish(new CheckedNewsOnNotExists(context.Message.NewsUrl));
            }
        }
    }
}
