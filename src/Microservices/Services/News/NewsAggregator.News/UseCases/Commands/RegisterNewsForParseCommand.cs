using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Messages;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RegisterNewsForParseCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public RegisterNewsForParseCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        internal class Validator : AbstractValidator<RegisterNewsForParseCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RegisterNewsForParseCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RegisterNewsForParseCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Add(new NewsParseNeed
                        {
                            NewsUrl = request.NewsUrl
                        });

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

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
