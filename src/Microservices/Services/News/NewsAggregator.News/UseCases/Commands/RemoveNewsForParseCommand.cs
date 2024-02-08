using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

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
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var newsParseNeed = await _repository.FindOneByExpressionAsync<NewsParseNeed>(news =>
                            news.NewsUrl == request.NewsUrl);

                        if (newsParseNeed != null) 
                        {
                            _repository.Remove(newsParseNeed);
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
