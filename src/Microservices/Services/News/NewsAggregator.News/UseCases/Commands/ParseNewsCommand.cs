using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Caching;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ParseNewsCommand : IRequest<NewsDto>
    {
        public string NewsUrl { get; }

        public ParseNewsCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        public class Validator : AbstractValidator<ParseNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ParseNewsCommand, NewsDto>
        {
            private readonly INewsSourceMemoryCache _cache;
            private readonly INewsParser _parser;
            private readonly INewsSourceRepository _repository;
            private readonly INewsHtmlPageProvider _newsHtmlPageProvider;

            public Handler(INewsSourceMemoryCache cache, INewsParser parser, INewsSourceRepository repository, 
                INewsHtmlPageProvider newsHtmlPageProvider)
            {
                _cache = cache;
                _parser = parser;
                _repository = repository;
                _newsHtmlPageProvider = newsHtmlPageProvider;
            }

            public async Task<NewsDto> Handle(ParseNewsCommand request, CancellationToken cancellationToken)
            {
                var newsUri = new Uri(request.NewsUrl);

                var newsSource = await _cache.GetNewsSourceBySiteUrlAsync($"{newsUri.Scheme}://{newsUri.Host}/",
                    async() =>
                    {
                        return await _repository.FindNewsSourceBySiteUrlAsync($"{newsUri.Scheme}://{newsUri.Host}/",
                            cancellationToken) ?? throw new NewsSourceNotFoundException(newsUri.Host);
                    },
                    cancellationToken);

                if (newsSource is not null && newsSource.ParseSettings is not null)
                {
                    var html = await _newsHtmlPageProvider.ProvideAsync(request.NewsUrl, 
                        cancellationToken);

                    return await _parser.ParseAsync(request.NewsUrl, html, 
                        newsSource.ParseSettings.ToNewsParserOptions(), cancellationToken);
                }
                else
                {
                    throw new NewsSourceNotFoundException(newsUri.Host);
                }
            }
        }

        internal class ParsedNewsNotificationHandler : INotificationHandler<ParsedNews>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<ParsedNewsNotificationHandler> _logger;

            public ParsedNewsNotificationHandler(IMessageBus messageBus, ILogger<ParsedNewsNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(ParsedNews notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Parsed news {0}", notification.News.Url);

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }

        internal class ThrowedExceptionWhenParseNewsNotificationHandler : INotificationHandler<ThrowedExceptionWhenParseNews>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<ThrowedExceptionWhenParseNewsNotificationHandler> _logger;

            public ThrowedExceptionWhenParseNewsNotificationHandler(IMessageBus messageBus,
                ILogger<ThrowedExceptionWhenParseNewsNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(ThrowedExceptionWhenParseNews notification, CancellationToken cancellationToken)
            {
                _logger.LogError("The news {0} parsing failed with an error {1}", notification.NewsUrl, notification.Message);

                await _messageBus.SendAsync(notification, cancellationToken);
            }

            internal class ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler : INotificationHandler<ThrowedHttpRequestExceptionWhenParseNews>
            {
                private readonly IMessageBus _messageBus;
                private readonly ILogger<ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler> _logger;

                public ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler(IMessageBus messageBus,
                    ILogger<ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler> logger)
                {
                    _messageBus = messageBus;
                    _logger = logger;
                }

                public async Task Handle(ThrowedHttpRequestExceptionWhenParseNews notification, CancellationToken cancellationToken)
                {
                    _logger.LogError("The news {0} parsing failed with an error {1}", notification.NewsUrl, notification.Message);

                    await _messageBus.SendAsync(notification, cancellationToken);
                }
            }
        }
    }
}
