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
    public class GetLiteNewsByUrlQuery : IRequest<Entities.News>
    {
        public string Url { get; }

        public GetLiteNewsByUrlQuery(string url)
        {
            Url = url;
        }

        public class Validator : AbstractValidator<GetLiteNewsByUrlQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Url).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<GetLiteNewsByUrlQuery, Entities.News>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Entities.News> Handle(GetLiteNewsByUrlQuery request, CancellationToken cancellationToken)
            {
                return await _repository.FindNewsBySpecificationAsync(
                    new GetLiteNewsSpecification(news => news.Url == request.Url),
                        cancellationToken) ?? throw new NewsNotFoundException(request.Url);
            }
        }

        internal class AddedNewsNotificationGeneratedNotificationHandler : INotificationHandler<AddedNewsNotificationGenerated>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<AddedNewsNotificationGeneratedNotificationHandler> _logger;

            public AddedNewsNotificationGeneratedNotificationHandler(IMessageBus messageBus, 
                ILogger<AddedNewsNotificationGeneratedNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(AddedNewsNotificationGenerated notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Send added news notification generated {0}", notification.News.Url);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
