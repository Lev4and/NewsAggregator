using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.Exceptions;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RemoveNewsSourceByIdCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public RemoveNewsSourceByIdCommand(Guid id)
        {
            Id = id;
        }

        public class Validator : AbstractValidator<RemoveNewsSourceByIdCommand>
        {
            public Validator()
            {
                RuleFor(command => command.Id).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RemoveNewsSourceByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;
            private readonly IMemoryCache _memoryCache;

            public Handler(IUnitOfWork unitOfWork, IRepository repository, IMemoryCache memoryCache)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
                _memoryCache = memoryCache;
            }

            public async Task<bool> Handle(RemoveNewsSourceByIdCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var newsSource = await _repository.FindOneByIdAsync<NewsSource>(request.Id, cancellationToken)
                            ?? throw new NewsSourceNotFoundException(request.Id);

                        _repository.Remove(newsSource);

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        await _memoryCache.RemoveAsync($"newssource:{request.Id}", cancellationToken);

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
