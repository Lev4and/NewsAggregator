using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class CheckedNewsOnNotExistsConsumer : IConsumer<CheckedNewsOnNotExists>
    {
        private readonly IMediator _mediator;

        public CheckedNewsOnNotExistsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<CheckedNewsOnNotExists> context)
        {
            var news = await _mediator.Send(new ParseNewsCommand(context.Message.NewsUrl));

            await _mediator.Publish(new ParsedNews(news));
        }
    }
}
