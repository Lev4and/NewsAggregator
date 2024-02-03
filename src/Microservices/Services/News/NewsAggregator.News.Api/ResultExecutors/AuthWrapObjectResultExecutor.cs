using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NewsAggregator.Infrastructure.Web.Http;
using System.Net;
using Microsoft.Extensions.Options;

namespace NewsAggregator.News.Api.ResultExecutors
{
    public class AuthWrapObjectResultExecutor : ObjectResultExecutor
    {
        public AuthWrapObjectResultExecutor(OutputFormatterSelector formatterSelector, IHttpResponseStreamWriterFactory writerFactory, 
            ILoggerFactory loggerFactory, IOptions<MvcOptions> mvcOptions) : base(formatterSelector, writerFactory, loggerFactory, mvcOptions)
        {

        }

        public override Task ExecuteAsync(ActionContext context, ObjectResult result)
        {
            var response = new ApiResponse<object>(result.Value, (HttpStatusCode?)result.StatusCode);

            var typeCode = Type.GetTypeCode(result.Value.GetType());

            if (typeCode == TypeCode.Object)
            {
                result.Value = response;
            }

            return base.ExecuteAsync(context, result);
        }
    }
}
