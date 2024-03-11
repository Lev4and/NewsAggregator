using MediatR;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsTagByIdQuery : IRequest<NewsTag>
    {
        public Guid Id { get; }

        public GetNewsTagByIdQuery(Guid id)
        {
            Id = id;
        }

        internal class Handler : IRequestHandler<GetNewsTagByIdQuery, NewsTag>
        {
            private readonly INewsTagsRepository _repository;

            public Handler(INewsTagsRepository repository)
            {
                _repository = repository;
            }

            public async Task<NewsTag> Handle(GetNewsTagByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.FindNewsTagByIdAsync(request.Id)
                    ?? throw new NewsTagNotFoundException(request.Id);
            }
        }
    }
}
