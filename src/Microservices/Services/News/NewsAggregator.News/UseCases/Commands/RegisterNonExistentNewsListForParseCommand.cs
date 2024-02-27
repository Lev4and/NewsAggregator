using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Messages;
using System.Transactions;

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
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
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

                        transaction.Complete();

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        internal class RegisteredNewsForParseNotificationHandler : INotificationHandler<RegisteredNewsForParse>
        {
            private readonly IMessageBus _messageBus;

            public RegisteredNewsForParseNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(RegisteredNewsForParse notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
