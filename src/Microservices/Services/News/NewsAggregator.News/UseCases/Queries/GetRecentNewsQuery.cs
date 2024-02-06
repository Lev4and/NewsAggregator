using FluentValidation;
using MediatR;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;
using ZstdSharp.Unsafe;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetRecentNewsQuery : IRequest<IReadOnlyCollection<Entities.News>>
    {
        public int Count { get; }

        public bool SubTitleRequired { get; }

        public bool PictureRequired { get; }

        public GetRecentNewsQuery(int count = 10, bool subTitleRequired = false, bool pictureRequired = false)
        {
            Count = count;
            SubTitleRequired = subTitleRequired;
            PictureRequired = pictureRequired;
        }

        internal class Validator : AbstractValidator<GetRecentNewsQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Count).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetRecentNewsQuery, IReadOnlyCollection<Entities.News>>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<Entities.News>> Handle(GetRecentNewsQuery request,
                CancellationToken cancellationToken)
            {
                return await _repository.FindAsync(new GetRecentNewsGridSpecification(new GetRecentNewsGridSpecificationOptions(request.Count, 
                    request.SubTitleRequired, request.PictureRequired)), cancellationToken);
            }
        }
    }
}
