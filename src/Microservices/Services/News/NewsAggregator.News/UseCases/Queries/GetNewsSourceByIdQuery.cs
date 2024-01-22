using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
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
            private readonly INewsSourceRepository _repository;
            private readonly IMemoryCache _memoryCache;

            public Handler(INewsSourceRepository repository, IMemoryCache memoryCache)
            {
                _repository = repository;
                _memoryCache = memoryCache;
            }

            public async Task<NewsSource> Handle(GetNewsSourceByIdQuery request, CancellationToken cancellationToken)
            {
                return await _memoryCache.GetAsync($"newssource:{request.Id}",
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
