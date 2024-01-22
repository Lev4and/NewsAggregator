using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsByIdQuery : IRequest<Entities.News>
    {
        public Guid Id { get; }

        public GetNewsByIdQuery(Guid id)
        {
            Id = id;
        }

        public class Validator : AbstractValidator<GetNewsByIdQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Id).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsByIdQuery, Entities.News>
        {
            private readonly INewsRepository _repository;
            private readonly IMemoryCache _memoryCache;

            public Handler(INewsRepository repository, IMemoryCache memoryCache)
            {
                _repository = repository;
                _memoryCache = memoryCache;
            }

            public async Task<Entities.News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                return await _memoryCache.GetAsync($"news:{request.Id}", 
                    async () =>
                    {
                        return await _repository.FindOneByIdAsync(request.Id, cancellationToken)
                            ?? throw new NewsNotFoundException(request.Id);
                    }, 
                    cancellationToken);
            }
        }
    }
}
