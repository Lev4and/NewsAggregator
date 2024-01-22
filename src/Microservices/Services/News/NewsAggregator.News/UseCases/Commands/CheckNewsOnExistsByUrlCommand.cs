using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class CheckNewsOnExistsByUrlCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public CheckNewsOnExistsByUrlCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        public class Validator : AbstractValidator<CheckNewsOnExistsByUrlCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<CheckNewsOnExistsByUrlCommand, bool>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(CheckNewsOnExistsByUrlCommand request, CancellationToken cancellationToken)
            {
                return await _repository.ContainsNewsByUrlAsync(request.NewsUrl);
            }
        }

        internal class CheckedNewsOnNotExistsNotificationHandler : INotificationHandler<CheckedNewsOnNotExists>
        {
            private readonly IMessageBus _messageBus;

            public CheckedNewsOnNotExistsNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(CheckedNewsOnNotExists notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
