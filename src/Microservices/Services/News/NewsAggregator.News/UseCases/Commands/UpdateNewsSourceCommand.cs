using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.UseCases.Commands
{
    public class UpdateNewsSourceCommand : IRequest<bool>
    {
        public NewsSource NewsSource { get; }

        public UpdateNewsSourceCommand(NewsSource newsSource)
        {
            NewsSource = newsSource;
        }

        public class Validator : AbstractValidator<UpdateNewsSourceCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsSource).NotNull();
            }
        }

        internal class Handler : IRequestHandler<UpdateNewsSourceCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(UpdateNewsSourceCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Update(request.NewsSource);

                        if (request.NewsSource.ParseSettings is not null)
                        {
                            _repository.Update(request.NewsSource.ParseSettings);
                        }

                        if (request.NewsSource.SearchSettings is not null)
                        {
                            _repository.Update(request.NewsSource.SearchSettings);
                        }

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
