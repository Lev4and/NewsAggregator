using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisterNewsSiteVisitConsumer : IConsumer<NewsSiteVisited>
    {
        private readonly IMediator _mediator;

        public RegisterNewsSiteVisitConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NewsSiteVisited> context)
        {
            await _mediator.Send(new RegisterNewsSiteVisitCommand(context.Message.IpAddress, 
                context.Message.VisitedAt));
        }
    }
}
