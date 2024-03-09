using FluentValidation;
using MediatR;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ContainsNewsViewByIpAddressCommand : IRequest<bool>
    {
        public Guid NewsId { get; }

        public string IpAddress { get; }

        public ContainsNewsViewByIpAddressCommand(Guid newsId, string ipAddress)
        {
            NewsId = newsId;
            IpAddress = ipAddress;
        }

        internal class Validator : AbstractValidator<ContainsNewsViewByIpAddressCommand>
        {
            public Validator()
            {
                RuleFor(query => query.IpAddress).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ContainsNewsViewByIpAddressCommand, bool>
        {
            private readonly INewsViewRepository _repository;

            public Handler(INewsViewRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(ContainsNewsViewByIpAddressCommand request, CancellationToken cancellationToken)
            {
                return await _repository.ContainsByNewsIdAndIpAddressAsync(request.NewsId, 
                    request.IpAddress, cancellationToken);
            }
        }
    }
}
