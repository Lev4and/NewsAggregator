using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using System.Transactions;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RemoveNewsForParseCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public RemoveNewsForParseCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        internal class Validator : AbstractValidator<RemoveNewsForParseCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RemoveNewsForParseCommand, bool> 
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RemoveNewsForParseCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var newsParseNeed = await _repository.FindOneByExpressionAsync<NewsParseNeed>(news =>
                            news.NewsUrl == request.NewsUrl);

                        if (newsParseNeed is not null) 
                        {
                            _repository.Remove(newsParseNeed);
                        }

                        await _unitOfWork.SaveChangesAsync();

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
