using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsByUrlQuery : IRequest<Entities.News>
    {
        public string Url { get; }

        public GetNewsByUrlQuery(string url)
        {
            Url = url;
        }

        public class Validator : AbstractValidator<GetNewsByUrlQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Url).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsByUrlQuery, Entities.News>
        {
            private readonly IMemoryCache _memoryCache;
            private readonly INewsRepository _repository;

            public Handler(IMemoryCache memoryCache, INewsRepository repository)
            {
                _memoryCache = memoryCache;
                _repository = repository;
            }

            public async Task<Entities.News> Handle(GetNewsByUrlQuery request, CancellationToken cancellationToken)
            {
                return await _memoryCache.GetAsync($"news:{request.Url}",
                    async () =>
                    {
                        return await _repository.FindNewsByUrlAsync(request.Url, cancellationToken)
                            ?? throw new NewsNotFoundException(request.Url);
                    }, 
                    cancellationToken);
            }
        }
    }
}
