using FluentValidation;
using MediatR;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class TestSearchNewsCommand : IRequest<IReadOnlyCollection<string>>
    {
        public string NewsSiteUrl { get; }

        public string NewsUrlXPath { get; }

        public TestSearchNewsCommand(string newsSiteUrl, string newsUrlXPath)
        {
            NewsSiteUrl = newsSiteUrl;
            NewsUrlXPath = newsUrlXPath;
        }

        public class Validator : AbstractValidator<TestSearchNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsSiteUrl).NotEmpty();
                RuleFor(command => command.NewsUrlXPath).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<TestSearchNewsCommand, IReadOnlyCollection<string>>
        {
            private readonly INewsUrlsParser _parser;

            public Handler(INewsUrlsParser parser)
            {
                _parser = parser;
            }

            public async Task<IReadOnlyCollection<string>> Handle(TestSearchNewsCommand request, 
                CancellationToken cancellationToken)
            {
                return await _parser.ParseAsync(request.NewsSiteUrl, 
                    new NewsUrlsParserOptions(request.NewsUrlXPath),
                        cancellationToken);
            }
        }
    }
}
