using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisterNewsReactionConsumer : IConsumer<NewsReacted>
    {
        private readonly IMediator _mediator;

        public RegisterNewsReactionConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NewsReacted> context)
        {
            var exists = await _mediator.Send(new ContainsNewsReactionCommand(context.Message.NewsId,
                context.Message.IpAddress));

            if (!exists)
            {
                await _mediator.Send(new RegisterNewsReactionCommand(context.Message.NewsId, context.Message.ReactionId, 
                    context.Message.IpAddress, context.Message.ReactedAt));
            }
        }
    }
}
