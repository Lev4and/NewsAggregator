using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class AddNewsConsumer : IConsumer<ParsedNews>
    {
        private readonly IMediator _mediator;

        public AddNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ParsedNews> context)
        {
            var result = await _mediator.Send(new AddNewsCommand(context.Message.News));

            if (result)
            {
                await _mediator.Publish(new AddedNews(context.Message.News.Url));
            }

            await _mediator.Publish(new ProcessedNews(context.Message.News.Url));
        }
    }
}
