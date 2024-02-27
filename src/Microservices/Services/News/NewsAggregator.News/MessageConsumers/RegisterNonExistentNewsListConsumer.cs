using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RegisterNonExistentNewsListConsumer : IConsumer<ListNonExistentNewsFormed>
    {
        private readonly IMediator _mediator;

        public RegisterNonExistentNewsListConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ListNonExistentNewsFormed> context)
        {
            var result = await _mediator.Send(new RegisterNonExistentNewsListForParseCommand(context.Message.NewsUrls));

            if (result)
            {
                foreach (var newsUrl in context.Message.NewsUrls)
                {
                    await _mediator.Publish(new RegisteredNewsForParse(newsUrl));
                }
            }
            else
            {
                await _mediator.Publish(context.Message);
            }
        }
    }
}
