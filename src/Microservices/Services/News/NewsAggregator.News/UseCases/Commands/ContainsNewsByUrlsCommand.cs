using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ContainsNewsByUrlsCommand : IRequest<IReadOnlyDictionary<string, bool>>
    {
        public IReadOnlyCollection<string> Urls { get; }

        public ContainsNewsByUrlsCommand(IReadOnlyCollection<string> urls)
        {
            Urls = urls;
        }

        internal class Validator : AbstractValidator<ContainsNewsByUrlsCommand> 
        {
            public Validator()
            {
                RuleFor(command => command.Urls).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ContainsNewsByUrlsCommand, IReadOnlyDictionary<string, bool>>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyDictionary<string, bool>> Handle(ContainsNewsByUrlsCommand request, 
                CancellationToken cancellationToken)
            {
                return await _repository.ContainsNewsByUrlsAsync(request.Urls, cancellationToken);
            }
        }
    }
}
