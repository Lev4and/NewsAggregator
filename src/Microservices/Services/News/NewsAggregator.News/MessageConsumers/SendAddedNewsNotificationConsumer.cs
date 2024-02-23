using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.MessageConsumers
{
    public class SendAddedNewsNotificationConsumer : IConsumer<AddedNews>
    {
        private readonly IMediator _mediator;

        public SendAddedNewsNotificationConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddedNews> context)
        {
            var addedNews = await _mediator.Send(new GetLiteNewsByUrlQuery(context.Message.NewsUrl));

            await _mediator.Publish(new AddedNewsNotificationGenerated(addedNews));
        }
    }
}
