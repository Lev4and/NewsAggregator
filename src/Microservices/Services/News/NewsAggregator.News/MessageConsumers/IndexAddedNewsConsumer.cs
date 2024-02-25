using Elastic.Clients.Elasticsearch;
using MassTransit;
using NewsAggregator.News.Messages;

namespace NewsAggregator.News.MessageConsumers
{
    public class IndexAddedNewsConsumer : IConsumer<AddedNewsPreparedToIndexing>
    {
        private readonly ElasticsearchClient _client;

        public IndexAddedNewsConsumer(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task Consume(ConsumeContext<AddedNewsPreparedToIndexing> context)
        {
            var response = await _client.IndexAsync(context.Message.News, "news");

            if (response.IsValidResponse)
            {

            }
        }
    }
}
