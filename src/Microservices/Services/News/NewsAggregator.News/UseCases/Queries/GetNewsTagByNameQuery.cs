using FluentValidation;
using MediatR;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsTagByNameQuery : IRequest<NewsTag>
    {
        public string Name { get; }

        public GetNewsTagByNameQuery(string name)
        {
            Name = name;
        }

        internal class Validator : AbstractValidator<GetNewsTagByNameQuery>
        {
            public Validator()
            {
                RuleFor(query => query).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetNewsTagByNameQuery, NewsTag>
        {
            private readonly INewsTagRepository _repository;

            public Handler(INewsTagRepository repository)
            {
                _repository = repository;
            }

            public async Task<NewsTag> Handle(GetNewsTagByNameQuery request, CancellationToken cancellationToken)
            {
                return await _repository.FindNewsTagByNameAsync(request.Name, cancellationToken)
                    ?? throw new NewsTagNotFoundException(request.Name);
            }
        }
    }
}
