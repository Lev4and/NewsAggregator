using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using System.Transactions;

namespace NewsAggregator.News.UseCases.Commands
{
    public class AddNewsParseNetworkErrorCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public string Message { get; }

        public DateTime CreatedAt { get; }

        public AddNewsParseNetworkErrorCommand(string newsUrl, string message, DateTime createdAt)
        {
            NewsUrl = newsUrl;
            Message = message;
            CreatedAt = createdAt;
        }

        internal class Validator : AbstractValidator<AddNewsParseNetworkErrorCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
                RuleFor(command => command.Message).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<AddNewsParseNetworkErrorCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(AddNewsParseNetworkErrorCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        _repository.Add(new NewsParseNetworkError
                        {
                            NewsUrl = request.NewsUrl,
                            Message = request.Message,
                            CreatedAt = request.CreatedAt
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
    }
}
