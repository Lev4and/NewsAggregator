using FluentValidation;
using MediatR;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class TestParseNewsCommand : IRequest<NewsDto>
    {
        public string NewsUrl { get; }

        public NewsParserOptions ParserOptions { get; }

        public TestParseNewsCommand(string newsUrl, NewsParserOptions parserOptions)
        {
            NewsUrl = newsUrl;
            ParserOptions = parserOptions;
        }

        public class Validator : AbstractValidator<TestParseNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
                RuleFor(command => command.ParserOptions).NotNull();
            }
        }

        internal class Handler : IRequestHandler<TestParseNewsCommand, NewsDto> 
        {
            private readonly INewsParser _parser;
            private readonly INewsHtmlPageProvider _newsHtmlPageProvider;

            public Handler(INewsParser parser, INewsHtmlPageProvider newsHtmlPageProvider)
            {
                _parser = parser;
                _newsHtmlPageProvider = newsHtmlPageProvider;
            }

            public async Task<NewsDto> Handle(TestParseNewsCommand request, CancellationToken cancellationToken)
            {
                var html = await _newsHtmlPageProvider.ProvideAsync(request.NewsUrl, 
                    cancellationToken);

                return await _parser.ParseAsync(request.NewsUrl, html, request.ParserOptions, 
                    cancellationToken);
            }
        }
    }
}
