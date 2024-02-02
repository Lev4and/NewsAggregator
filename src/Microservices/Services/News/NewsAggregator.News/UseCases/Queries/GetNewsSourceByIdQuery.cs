using FluentValidation;
using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsSourceByIdQuery : IRequest<NewsSource>
    {
        public Guid Id { get; }

        public GetNewsSourceByIdQuery(Guid id)
        {
            Id = id;
        }

        public class Validator : AbstractValidator<GetNewsSourceByIdQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Id).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsSourceByIdQuery, NewsSource>
        {
            private readonly INewsSourceMemoryCache _cache;
            private readonly INewsSourceRepository _repository;

            public Handler(INewsSourceMemoryCache cache, INewsSourceRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<NewsSource> Handle(GetNewsSourceByIdQuery request, CancellationToken cancellationToken)
            {
                return await _cache.GetNewsSourceByIdAsync(request.Id,
                    async () =>
                    {
                        return await _repository.FindNewsSourceByIdAsync(request.Id, cancellationToken)
                            ?? throw new NewsSourceNotFoundException(request.Id);
                    },
                    cancellationToken);
            }
        }
    }
}
