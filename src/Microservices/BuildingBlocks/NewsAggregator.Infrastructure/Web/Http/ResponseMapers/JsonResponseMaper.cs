using Newtonsoft.Json;
using System.Net;

namespace NewsAggregator.Infrastructure.Web.Http.ResponseMapers
{
    public class JsonResponseMaper : IResponseMaper
    {
        public ApiResponse<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return new ApiResponse<TResult>(JsonConvert.DeserializeObject<TResult>(responseContent), 
                statusCode);
        }
    }
}
