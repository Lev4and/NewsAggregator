using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;
using System.Transactions;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RegisterNewsViewCommand : IRequest<bool>
    {
        public Guid NewsId { get; }

        public string IpAddress { get; }

        public DateTime ViewedAt { get; }

        public RegisterNewsViewCommand(Guid newsId, string ipAddress, DateTime viewedAt)
        {
            NewsId = newsId;
            IpAddress = ipAddress;
            ViewedAt = viewedAt;
        }

        internal class Validator : AbstractValidator<RegisterNewsViewCommand>
        {
            public Validator()
            {
                RuleFor(command => command.IpAddress).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RegisterNewsViewCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RegisterNewsViewCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        _repository.Add(
                            new NewsView
                            {
                                NewsId = request.NewsId,
                                IpAddress = request.IpAddress,
                                ViewedAt = request.ViewedAt
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
