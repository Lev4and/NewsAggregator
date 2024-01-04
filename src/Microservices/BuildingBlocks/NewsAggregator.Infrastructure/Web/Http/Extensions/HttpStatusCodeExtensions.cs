using System.Net;

namespace NewsAggregator.Infrastructure.Web.Http.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static bool IsErrorStatusCode(this HttpStatusCode? code)
        {
            return code >= HttpStatusCode.BadRequest;
        }
    }
}
