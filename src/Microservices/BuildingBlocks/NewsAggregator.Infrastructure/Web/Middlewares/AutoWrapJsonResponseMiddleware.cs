using NewsAggregator.Infrastructure.Web.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace NewsAggregator.Infrastructure.Web.Middlewares
{
    public class AutoWrapJsonResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public AutoWrapJsonResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (var stream = new MemoryStream())
            {
                context.Response.Body = stream;

                try
                {
                    await _next(context);

                    if (context.Response.ContentType == "application/json; charset=utf-8")
                    {
                        await WrapNotThrownExceptionJsonResponseAsync(context.Response);
                    }
                }
                catch (Exception ex) 
                {
                    await WrapThrownExceptionJsonResponseAsync(context.Response, ex);
                }
                finally
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    await stream.CopyToAsync(originalBodyStream);
                }
            }
        }

        private async Task WrapNotThrownExceptionJsonResponseAsync(HttpResponse response, 
            CancellationToken cancellationToken = default)
        {
            var responseBodyText = await ReadResponseBodyAsync(response.Body, cancellationToken);
            var responseBody = JsonConvert.DeserializeObject(responseBodyText);

            var newResponseBody = new ApiResponse<object>(responseBody, (HttpStatusCode)response.StatusCode);
            var newResponseBodyText = JsonConvert.SerializeObject(newResponseBody);

            await response.WriteAsync(newResponseBodyText, cancellationToken);
        }

        private async Task WrapThrownExceptionJsonResponseAsync(HttpResponse response, Exception exception,
            CancellationToken cancellationToken = default)
        {
            var newResponseBody = new ApiResponse<object>(null, HttpStatusCode.BadGateway, exception.Message, exception);
            var newResponseBodyText = JsonConvert.SerializeObject(newResponseBody);

            response.ContentType = "application/json; charset=utf-8";
            response.StatusCode = (int)HttpStatusCode.BadGateway;

            await response.WriteAsync(newResponseBodyText, cancellationToken);
        }

        private async Task<string> ReadResponseBodyAsync(Stream body, 
            CancellationToken cancellationToken = default)
        {
            body.Seek(0, SeekOrigin.Begin);

            var responseBodyText = await new StreamReader(body).ReadToEndAsync(cancellationToken);

            body.Seek(0, SeekOrigin.Begin);

            return responseBodyText;
        }
    }
}
