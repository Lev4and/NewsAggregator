using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using System.Net;

namespace NewsAggregator.News.Web.Middlewares
{
    public class RegisterNewsSiteVisitMiddleware
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly RequestDelegate _next;

        public RegisterNewsSiteVisitMiddleware(IServiceScopeFactory scopeFactory, RequestDelegate next)
        {
            _scopeFactory = scopeFactory;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

                    await mediator.Publish(new NewsSiteVisited(context.GetConnectionIpAddress()));
                }
            }
        }
    }
}
