using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class CheckAndRegisterNonExistentNewsConsumer : IConsumer<FoundNewsList>
    {
        private readonly IMediator _mediator;

        public CheckAndRegisterNonExistentNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<FoundNewsList> context)
        {
            var containedNewsDictionary = await _mediator.Send(new ContainsNewsByUrlsCommand(context.Message.NewsUrls));

            var nonExistentNews = containedNewsDictionary
                .Where(pair => !pair.Value)
                    .Select(pair => pair.Key)
                        .ToList();

            var registerNewsListResult = await _mediator.Send(new RegisterNonExistentNewsListForParseCommand(nonExistentNews));

            if (registerNewsListResult)
            {
                foreach (var newsUrl in nonExistentNews)
                {
                    await _mediator.Publish(new RegisteredNewsForParse(newsUrl));
                }
            }
        }
    }
}
