using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Indexers;

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
            private readonly IIndexer _indexer;

            public Handler(IIndexer indexer)
            {
                _indexer = indexer;
            }

            public async Task<bool> Handle(IndexNewsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await _indexer.IndexAsync(request.News, cancellationToken);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
