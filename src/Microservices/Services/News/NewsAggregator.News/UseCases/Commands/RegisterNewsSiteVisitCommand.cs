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
    public class RegisterNewsSiteVisitCommand : IRequest<bool>
    {
        public string IpAddress { get; }

        public DateTime VisitedAt { get; }

        public RegisterNewsSiteVisitCommand(string ipAddress, DateTime visitedAt)
        {
            IpAddress = ipAddress;
            VisitedAt = visitedAt;
        }

        internal class Validator : AbstractValidator<RegisterNewsSiteVisitCommand>
        {
            public Validator()
            {
                RuleFor(command => command.IpAddress).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RegisterNewsSiteVisitCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RegisterNewsSiteVisitCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        _repository.Add(
                            new NewsSiteVisit
                            {
                                IpAddress = request.IpAddress,
                                VisitedAt = request.VisitedAt
                            });

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

        internal class NewsSiteVisitedNotificationHandler : INotificationHandler<NewsSiteVisited>
        {
            private readonly IMessageBus _messageBus;

            public NewsSiteVisitedNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(NewsSiteVisited notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
