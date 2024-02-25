using Elastic.Clients.Elasticsearch;
using FluentValidation;
using MediatR;

namespace NewsAggregator.News.UseCases.Commands
{
    public class IndexNewsCommand : IRequest<bool>
    {
        public Entities.News News { get; }

        public IndexNewsCommand(Entities.News news)
        {
            News = news;
        }

        internal class Validator : AbstractValidator<IndexNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.News).NotNull();
            }
        }

        internal class Handler : IRequestHandler<IndexNewsCommand, bool> 
        {
            private readonly ElasticsearchClient _client;

            public Handler(ElasticsearchClient client)
            {
                _client = client;
            }

            public async Task<bool> Handle(IndexNewsCommand request, CancellationToken cancellationToken)
            {
                var response = await _client.IndexAsync(request.News, IndexName.From<Entities.News>(), 
                    cancellationToken);

                return response.IsValidResponse;
            }
        }
    }
}
