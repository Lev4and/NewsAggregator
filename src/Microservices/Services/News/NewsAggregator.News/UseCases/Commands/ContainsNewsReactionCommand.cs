using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ContainsNewsReactionCommand : IRequest<bool>
    {
        public Guid NewsId { get; }

        public string IpAddress { get; }

        public ContainsNewsReactionCommand(Guid newsId, string ipAddress)
        {
            NewsId = newsId;
            IpAddress = ipAddress;
        }

        internal class Validator : AbstractValidator<ContainsNewsReactionCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsId).NotEmpty();
                RuleFor(command => command.IpAddress).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ContainsNewsReactionCommand, bool>
        {
            private readonly INewsReactionRepository _repository;

            public Handler(INewsReactionRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(ContainsNewsReactionCommand request, CancellationToken cancellationToken)
            {
                return await _repository.ContainsAsync(request.NewsId,
                    request.IpAddress, cancellationToken);
            }
        }

        internal class NewsReactedNotificationHandler : INotificationHandler<NewsReacted>
        {
            private readonly IMessageBus _messageBus;

            public NewsReactedNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(NewsReacted notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
