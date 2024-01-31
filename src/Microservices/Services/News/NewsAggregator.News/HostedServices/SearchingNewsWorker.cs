using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.HostedServices
{
    public class SearchingNewsWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<SearchingNewsWorker> _logger;

        public SearchingNewsWorker(IServiceScopeFactory scopeFactory, ILogger<SearchingNewsWorker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                using (var scope = _scopeFactory.CreateScope()) 
                {
                    _logger.LogInformation("Started search news");

                    var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

                    var newsSources = await mediator.Send(new GetAvailableNewsSourcesQuery(), stoppingToken);

                    foreach (var newsSource in newsSources)
                    {
                        _logger.LogInformation("Search news in {0}", newsSource.Title);

                        try
                        {
                            var newsUrls = await mediator.Send(new SearchNewsByNewsSourceCommand(newsSource), stoppingToken);

                            _logger.LogInformation("Found {0} news from {1}", newsUrls.Count, newsSource.SiteUrl);

                            await mediator.Publish(new FoundNewsUrls(newsUrls), stoppingToken);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    _logger.LogInformation("Ended search news");

                    await Task.Delay(60 * 1000);
                }
            }
        }
    }
}
