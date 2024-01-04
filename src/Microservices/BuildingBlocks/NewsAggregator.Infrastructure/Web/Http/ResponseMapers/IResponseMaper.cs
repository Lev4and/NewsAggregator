using System.Net;

namespace NewsAggregator.Infrastructure.Web.Http.ResponseMapers
{
    public interface IResponseMaper
    {
        ApiResponse<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
