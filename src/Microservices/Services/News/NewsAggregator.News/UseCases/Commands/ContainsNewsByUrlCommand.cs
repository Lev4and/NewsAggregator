using FluentValidation;
using MediatR;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ContainsNewsByUrlCommand : IRequest<bool>
    {
        public string NewsUrl { get; }

        public ContainsNewsByUrlCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        public class Validator : AbstractValidator<ContainsNewsByUrlCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ContainsNewsByUrlCommand, bool>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(ContainsNewsByUrlCommand request, CancellationToken cancellationToken)
            {
                return await _repository.ContainsNewsByUrlAsync(request.NewsUrl);
            }
        }
    }
}
