using FluentValidation;
using Microsoft.AspNetCore.Http;
using NewsAggregator.Infrastructure.Web.Http;
using NewsAggregator.News.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace NewsAggregator.News.Web.Middlewares
{
    public class AutoExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public AutoExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await WrapThrownExceptionJsonResponseAsync(context.Response, ex, HttpStatusCode.BadRequest);
            }
            catch (NotFoundException ex)
            {
                await WrapThrownExceptionJsonResponseAsync(context.Response, ex, HttpStatusCode.NotFound);
            }
        }

        private async Task WrapThrownExceptionJsonResponseAsync(HttpResponse response, Exception exception,
            HttpStatusCode httpStatusCode, CancellationToken cancellationToken = default)
        {
            var newResponseBody = new ApiResponse<object>(null, httpStatusCode, exception);
            var newResponseBodyText = JsonConvert.SerializeObject(newResponseBody);

            await response.WriteAsync(newResponseBodyText, cancellationToken);
        }
    }
}
