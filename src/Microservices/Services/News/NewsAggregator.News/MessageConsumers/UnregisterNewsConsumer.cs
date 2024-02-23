using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class UnregisterNewsConsumer : IConsumer<ProcessedNews>
    {
        private readonly IMediator _mediator;

        public UnregisterNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ProcessedNews> context)
        {
            var result = await _mediator.Send(new RemoveNewsForParseCommand(context.Message.NewsUrl));

            if (!result)
            {
                await _mediator.Publish(context.Message);
            }
        }
    }
}
