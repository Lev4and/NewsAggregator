using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsAggregator.News.Messages;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;

namespace NewsAggregator.News.HostedServices
{
    public class SearchingNewsWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SearchingNewsWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope()) 
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

                    var newsSources = await mediator.Send(new GetNewsSourcesQuery(), stoppingToken);

                    foreach (var newsSource in newsSources)
                    {
                        var newsUrls = await mediator.Send(new SearchNewsCommand(newsSource.SiteUrl));

                        foreach (var newsUrl in newsUrls)
                        {
                            await mediator.Publish(new FoundNews(newsUrl));
                        }
                    }

                    await Task.Delay(60 * 1000);
                }
            }
        }
    }
}
