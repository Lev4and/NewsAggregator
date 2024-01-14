using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.News.Extensions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNewsParsers();
        }
    }
}
