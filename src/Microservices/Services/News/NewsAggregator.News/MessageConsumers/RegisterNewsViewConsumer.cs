using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisterNewsViewConsumer : IConsumer<NewsViewed>
    {
        private readonly IMediator _mediator;

        public RegisterNewsViewConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NewsViewed> context)
        {
            var exists = await _mediator.Send(new ContainsNewsViewByIpAddressCommand(context.Message.NewsId, 
                context.Message.IpAddress));

            if (!exists)
            {
                await _mediator.Send(new RegisterNewsViewCommand(context.Message.NewsId, context.Message.IpAddress,
                    context.Message.ViewedAt));
            }
        }
    }
}
