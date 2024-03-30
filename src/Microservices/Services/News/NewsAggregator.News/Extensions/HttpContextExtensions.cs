using Microsoft.AspNetCore.Http;

namespace NewsAggregator.News.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetConnectionIpAddress(this HttpContext context)
        {
            return context.Request.Headers.FirstOrDefault(header => header.Key == "X-Real-IP").Value.FirstOrDefault()
                ?? context.Connection.RemoteIpAddress?.ToString()
                    ?? string.Empty;
        }
    }
}
