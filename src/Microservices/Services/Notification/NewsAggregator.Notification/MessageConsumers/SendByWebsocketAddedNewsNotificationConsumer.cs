using MassTransit;
using MediatR;
using NewsAggregator.Notification.Messages;
using NewsAggregator.Notification.UseCases.Commands;

namespace NewsAggregator.Notification.MessageConsumers
{
    public class SendByWebsocketAddedNewsNotificationConsumer : IConsumer<AddedNewsNotification>
    {
        private readonly IMediator _mediator;

        public SendByWebsocketAddedNewsNotificationConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddedNewsNotification> context)
        {
            await _mediator.Send(new SendByWebsocketAddedNewsNotificationCommand(context.Message.News));
        }
    }
}
