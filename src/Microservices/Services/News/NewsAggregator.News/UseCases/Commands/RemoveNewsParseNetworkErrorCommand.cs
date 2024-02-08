using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RemoveNewsParseNetworkErrorCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public RemoveNewsParseNetworkErrorCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        internal class Validator : AbstractValidator<RemoveNewsParseNetworkErrorCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RemoveNewsParseNetworkErrorCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RemoveNewsParseNetworkErrorCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var newsParseNetworkError = await _repository.FindOneByExpressionAsync<NewsParseNetworkError>(news =>
                            news.NewsUrl == request.NewsUrl);

                        if (newsParseNetworkError != null)
                        {
                            _repository.Remove(newsParseNetworkError);
                        }

                        await _unitOfWork.SaveChangesAsync();

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
