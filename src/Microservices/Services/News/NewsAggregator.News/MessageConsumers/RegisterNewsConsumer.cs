using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisterNewsConsumer : IConsumer<FoundNotExistedNews>
    {
        private readonly IMediator _mediator;

        public RegisterNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNotExistedNews> context)
        {
            var result = await _mediator.Send(new RegisterNewsForParseCommand(context.Message.NewsUrl));

            if (result)
            {
                await _mediator.Publish(new RegisteredNewsForParse(context.Message.NewsUrl));
            }
            else
            {
                await _mediator.Publish(context.Message);
            }
        }
    }
}
