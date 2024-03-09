using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;

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
            private readonly INewsMemoryCache _cache;
            private readonly INewsRepository _repository;

            public Handler(INewsMemoryCache cache, INewsRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<Entities.News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                return await _cache.GetNewsByIdAsync(request.Id,
                    async () =>
                    {
                        return await _repository.FindNewsBySpecificationAsync(
                            new GetExtendedNewsSpecification(news => news.Id == request.Id), 
                                cancellationToken) ?? throw new NewsNotFoundException(request.Id);
                    },
                    cancellationToken);
            }
        }

        internal class NewsViewedNotificationHandler : INotificationHandler<NewsViewed> 
        {
            private readonly IMessageBus _messageBus;

            public NewsViewedNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(NewsViewed notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
