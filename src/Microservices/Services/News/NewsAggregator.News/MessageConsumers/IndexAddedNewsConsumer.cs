using MassTransit;
using MediatR;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;

namespace NewsAggregator.News.MessageConsumers
{
    public class IndexAddedNewsConsumer : IConsumer<AddedNewsPreparedToIndexing>
    {
        private readonly IMediator _mediator;

        public IndexAddedNewsConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddedNewsPreparedToIndexing> context)
        {
            await _mediator.Send(new IndexNewsCommand(context.Message.News));
        }
    }
}
