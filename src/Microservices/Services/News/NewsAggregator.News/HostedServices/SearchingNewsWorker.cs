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
                    var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

                    var newsSources = await mediator.Send(new GetAvailableNewsSourcesQuery(), stoppingToken);

                    foreach (var newsSource in newsSources)
                    {
                        try
                        {
                            var newsUrls = await mediator.Send(new SearchNewsByNewsSourceCommand(newsSource), stoppingToken);

                            await mediator.Publish(new FoundNewsList(newsUrls), stoppingToken);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "The searching news list from {0} source failed with an error {1}",
                                newsSource.SiteUrl, ex.Message);

                            continue;
                        }
                    }
                }
            }
        }
    }
}
