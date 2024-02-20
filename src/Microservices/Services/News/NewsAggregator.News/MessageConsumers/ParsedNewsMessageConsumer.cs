using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.MessageConsumers
{
    public class ParsedNewsMessageConsumer : IConsumer<ParsedNews>
    {
        private readonly IMediator _mediator;

        public ParsedNewsMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ParsedNews> context)
        {
            await _mediator.Send(new AddNewsCommand(context.Message.News));

            var addedNews = await _mediator.Send(new GetLiteNewsByUrlQuery(context.Message.News.Url));

            await _mediator.Publish(new AddedNews(addedNews));
        }
    }
}
