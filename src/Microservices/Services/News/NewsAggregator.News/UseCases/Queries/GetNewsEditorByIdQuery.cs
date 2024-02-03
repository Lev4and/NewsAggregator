using FluentValidation;
using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsEditorByIdQuery : IRequest<NewsEditor>
    {
        public Guid Id { get; }

        public GetNewsEditorByIdQuery(Guid id)
        {
            Id = id;
        }

        internal class Validator : AbstractValidator<GetNewsEditorByIdQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Id).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsEditorByIdQuery, NewsEditor> 
        {
            private readonly INewsEditorMemoryCache _cache;
            private readonly INewsEditorRepository _repository;

            public Handler(INewsEditorMemoryCache cache, INewsEditorRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<NewsEditor> Handle(GetNewsEditorByIdQuery request, CancellationToken cancellationToken)
            {
                return await _cache.GetNewsEditorByIdAsync(request.Id,
                    async () =>
                    {
                        return await _repository.FindNewsEditorByIdAsync(request.Id)
                            ?? throw new NewsEditorNotFoundException(request.Id);
                    },
                    cancellationToken);
            }
        }
    }
}
