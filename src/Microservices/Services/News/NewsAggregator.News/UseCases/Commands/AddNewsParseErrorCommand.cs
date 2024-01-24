using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.UseCases.Commands
{
    public class AddNewsParseErrorCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public DateTime CreatedAt { get; }

        public Exception Exception { get; }

        public AddNewsParseErrorCommand(string newsUrl, DateTime createdAt, Exception exception)
        {
            NewsUrl = newsUrl;
            CreatedAt = createdAt;
            Exception = exception;
        }

        internal class Validator : AbstractValidator<AddNewsParseErrorCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
                RuleFor(command => command.Exception).NotNull();
            }
        }

        internal class Handler : IRequestHandler<AddNewsParseErrorCommand, bool> 
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(AddNewsParseErrorCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Add(new NewsParseError
                        {
                            NewsUrl = request.NewsUrl,
                            Message = request.Exception.Message,
                            CreatedAt = request.CreatedAt
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
    }
}
