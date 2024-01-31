using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ContainsNewsByUrlsCommand : IRequest<IReadOnlyDictionary<string, bool>>
    {
        public IReadOnlyCollection<string> Urls { get; }

        public ContainsNewsByUrlsCommand(IReadOnlyCollection<string> urls)
        {
            Urls = urls;
        }

        internal class Validator : AbstractValidator<ContainsNewsByUrlsCommand> 
        {
            public Validator()
            {
                RuleFor(command => command.Urls).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ContainsNewsByUrlsCommand, IReadOnlyDictionary<string, bool>>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyDictionary<string, bool>> Handle(ContainsNewsByUrlsCommand request, 
                CancellationToken cancellationToken)
            {
                return await _repository.ContainsNewsByUrlsAsync(request.Urls, cancellationToken);
            }
        }

        internal class NotContainedNewsHandler : INotificationHandler<NotContainedNews>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<NotContainedNewsHandler> _logger;

            public NotContainedNewsHandler(IMessageBus messageBus, ILogger<NotContainedNewsHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(NotContainedNews notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Found not contained news {0}", notification.NewsUrl);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
