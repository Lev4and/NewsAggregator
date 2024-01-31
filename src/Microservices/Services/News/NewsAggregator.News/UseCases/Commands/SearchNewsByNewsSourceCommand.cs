using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class SearchNewsByNewsSourceCommand : IRequest<IReadOnlyCollection<string>>
    {
        public NewsSource Source { get; }

        public SearchNewsByNewsSourceCommand(NewsSource source)
        {
            Source = source;
        }

        internal class Validator : AbstractValidator<SearchNewsByNewsSourceCommand>
        {
            public Validator()
            {
                RuleFor(command => command.Source).NotNull();
                RuleFor(command => command.Source.SearchSettings).NotNull();
            }
        }

        internal class Handler : IRequestHandler<SearchNewsByNewsSourceCommand, IReadOnlyCollection<string>>
        {
            private readonly INewsUrlsParser _parser;
            private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;

            public Handler(INewsUrlsParser parser, INewsListHtmlPageProvider newsListHtmlPageProvider)
            {
                _parser = parser;
                _newsListHtmlPageProvider = newsListHtmlPageProvider;
            }

            public async Task<IReadOnlyCollection<string>> Handle(SearchNewsByNewsSourceCommand request, 
                CancellationToken cancellationToken)
            {
                if (request.Source.SearchSettings is null)
                    return new List<string>();

                var html = await _newsListHtmlPageProvider.ProvideAsync(request.Source.SearchSettings.NewsSiteUrl,
                    cancellationToken);

                return await _parser.ParseAsync(request.Source.SearchSettings.NewsSiteUrl, html,
                    request.Source.SearchSettings.ToNewsUrlsParserOptions(), cancellationToken);
            }
        }

        internal class FoundNewsUrlsNotificationHandler : INotificationHandler<FoundNewsUrls>
        {
            private readonly IMessageBus _messageBus;
            private readonly ILogger<FoundNewsUrlsNotificationHandler> _logger;

            public FoundNewsUrlsNotificationHandler(IMessageBus messageBus, ILogger<FoundNewsUrlsNotificationHandler> logger)
            {
                _messageBus = messageBus;
                _logger = logger;
            }

            public async Task Handle(FoundNewsUrls notification, CancellationToken cancellationToken)
            {
                foreach (var newsUrl in notification.NewsUrls) 
                {
                    _logger.LogInformation("Found news {0}", newsUrl);
                }

                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
