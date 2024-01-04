using NewsAggregator.Infrastructure.Web.Http.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace NewsAggregator.Infrastructure.Web.Http
{
    public class ApiResponse<TResult>
    {
        [JsonProperty("isError")]
        public bool IsError => Code.IsErrorStatusCode() || Exception != null;

        [JsonProperty("message")]
        public string? Message { get; }

        [JsonProperty("result")]
        public TResult? Result { get; }

        [JsonProperty("code")]
        public HttpStatusCode? Code { get; }

        [JsonProperty("exception")]
        public Exception? Exception { get; }

        [JsonConstructor]
        public ApiResponse()
        {
            Message = null;
            Result = default(TResult);
            Code = null;
            Exception = null;
        }

        public ApiResponse(TResult? result, HttpStatusCode? code, string? message,
            Exception? exception = null)
        {
            Message = message;
            Code = code;
            Result = result;
            Exception = exception;
        }

        public ApiResponse(TResult? result, HttpStatusCode? code, Exception? exception = null) : 
            this(result, code, code?.ToString(), exception)
        {

        }
    }
}
