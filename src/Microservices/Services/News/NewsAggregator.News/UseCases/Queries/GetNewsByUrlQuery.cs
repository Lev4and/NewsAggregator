using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;

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
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Entities.News> Handle(GetNewsByUrlQuery request, CancellationToken cancellationToken)
            {
                return await _repository.FindNewsBySpecificationAsync(
                    new GetExtendedNewsSpecification(news => news.Url == request.Url), 
                        cancellationToken) ?? throw new NewsNotFoundException(request.Url);
            }
        }

        internal class AddedNewsPreparedToIndexingNotificationHandler : INotificationHandler<AddedNewsPreparedToIndexing>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<AddedNewsPreparedToIndexingNotificationHandler> _logger;

            public AddedNewsPreparedToIndexingNotificationHandler(IMessageBus messageBus, 
                ILogger<AddedNewsPreparedToIndexingNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(AddedNewsPreparedToIndexing notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Added news {0} prepared to indexing", notification.News.Url);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
