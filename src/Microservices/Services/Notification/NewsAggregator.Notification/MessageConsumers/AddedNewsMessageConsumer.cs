using MassTransit;
using MediatR;
using NewsAggregator.Notification.Messages;
using NewsAggregator.Notification.UseCases.Commands;

namespace NewsAggregator.Notification.MessageConsumers
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
            await _mediator.Send(new SendWebsocketAddedNewsNotificationCommand(context.Message.News));
        }
    }
}
