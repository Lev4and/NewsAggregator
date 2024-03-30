using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RegisterNewsReactionCommand : IRequest<bool>
    {
        public Guid NewsId { get; }

        public Guid ReactionId { get; }

        public string IpAddress { get; }

        public DateTime ReactedAt { get; }

        public RegisterNewsReactionCommand(Guid newsId, Guid reactionId, string ipAddress, DateTime reactedAt)
        {
            NewsId = newsId;
            ReactionId = reactionId;
            IpAddress = ipAddress;
            ReactedAt = reactedAt;
        }

        internal class Validator : AbstractValidator<RegisterNewsReactionCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsId).NotEmpty();
                RuleFor(command => command.ReactionId).NotEmpty();
                RuleFor(command => command.IpAddress).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<RegisterNewsReactionCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(RegisterNewsReactionCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Add(
                            new NewsReaction
                            {
                                NewsId = request.NewsId,
                                ReactionId = request.ReactionId,
                                IpAddress = request.IpAddress,
                                ReactedAt = request.ReactedAt
                            });

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync();

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync();

                        return false;
                    }
                }
            }
        }
    }
}
