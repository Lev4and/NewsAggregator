using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class AddedNewsMessageConsumer : IConsumer<AddedNews>
    {
        private readonly IMediator _mediator;

        public AddedNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddedNews> context)
        {
            await _mediator.Send(new RemoveNewsForParseCommand(context.Message.NewsUrl));
        }
    }
}
