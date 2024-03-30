using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Messages;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RegisterNonExistentNewsListForParseCommand : IRequest<bool>
    {
        public IReadOnlyCollection<string> NewsUrls { get; }

        public RegisterNonExistentNewsListForParseCommand(IReadOnlyCollection<string> newsUrls)
        {
            NewsUrls = newsUrls;
        }

        internal class Validator : AbstractValidator<RegisterNonExistentNewsListForParseCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrls).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RegisterNonExistentNewsListForParseCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RegisterNonExistentNewsListForParseCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        foreach (var newsUrl in request.NewsUrls)
                        {
                            _repository.Add(new NewsParseNeed
                            {
                                NewsUrl = newsUrl
                            });
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync();

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync();

                        return false;
                    }
                }
            }
        }

        internal class RegisteredNewsForParseNotificationHandler : INotificationHandler<RegisteredNewsForParse>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<RegisteredNewsForParseNotificationHandler> _logger;

            public RegisteredNewsForParseNotificationHandler(IMessageBus messageBus, ILogger<RegisteredNewsForParseNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(RegisteredNewsForParse notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Registered news {0} for parse", notification.NewsUrl);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
