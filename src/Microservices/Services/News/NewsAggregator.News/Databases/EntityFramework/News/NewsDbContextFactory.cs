using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace NewsAggregator.News.Databases.EntityFramework.News
{
    public class NewsDbContextFactory : IDesignTimeDbContextFactory<NewsDbContext>
    {
        public NewsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();

            builder
                .UseNpgsql("", builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
                .UseSnakeCaseNamingConvention();

            return new NewsDbContext(builder.Options);
        }
    }
}
