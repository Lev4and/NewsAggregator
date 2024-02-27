using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class ContainsNewsByUrlsConsumer : IConsumer<FoundNewsList>
    {
        private readonly IMediator _mediator;

        public ContainsNewsByUrlsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNewsList> context)
        {
            var dictionary = await _mediator.Send(new ContainsNewsByUrlsCommand(context.Message.NewsUrls));

            var nonExistentNews = dictionary.Where(pair => !pair.Value)
                .Select(pair => pair.Key)
                .ToList();

            await _mediator.Publish(new ListNonExistentNewsFormed(nonExistentNews));
        }
    }
}
