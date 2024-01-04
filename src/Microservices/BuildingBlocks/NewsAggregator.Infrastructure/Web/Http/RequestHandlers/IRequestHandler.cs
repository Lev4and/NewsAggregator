using NewsAggregator.Infrastructure.Web.Http.ResponseMapers;
using NewsAggregator.Infrastructure.Web.Http.ResponseReaders;

namespace NewsAggregator.Infrastructure.Web.Http.RequestHandlers
{
    public interface IRequestHandler
    {
        IResponseMaper Maper { get; }

        IResponseReader Reader { get; }

        Task<ApiResponse<TResult>> HandleAsync<TResult>(Func<Task<HttpResponseMessage>> request);
    }
}
