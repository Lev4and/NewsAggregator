using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.News.Extensions;

namespace NewsAggregator.News.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultNewsSources();
            services.AddHttpClientNewsProviders();
            services.AddNewsAngleSharpParsers();
        }
    }
}
