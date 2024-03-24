using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class RefreshNewsSourcesMemoryCacheConsumer : IConsumer<NewsSourceListNotFound>
    {
        private readonly IMediator _mediator;

        public RefreshNewsSourcesMemoryCacheConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<NewsSourceListNotFound> context)
        {
            await _mediator.Send(new RefreshNewsSourcesMemoryCacheCommand());
        }
    }
}
