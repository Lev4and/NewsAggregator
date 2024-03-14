using NewsAggregator.Infrastructure.Web.Http.Builders;
using NewsAggregator.Infrastructure.Web.Http.Extensions;
using NewsAggregator.Infrastructure.Web.Http.RequestHandlers;

namespace NewsAggregator.Infrastructure.Web.Http
{
    public class BaseHttpClient : HttpClient
    {
        protected virtual IRequestHandler RequestHandler => new RequestHandler();

        public BaseHttpClient() : base(new HttpClientHandlerBuilder().UseProxy().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().UseProxy().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            BaseAddress = new Uri(uri);
        }

        public BaseHttpClient(Uri uri) : base(new HttpClientHandlerBuilder().UseProxy().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {
            BaseAddress = uri;
        }

        public virtual async Task<ApiResponse<TResult>> GetAsync<TResult>(string uri,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await GetAsync<TResult>(new Uri(uri, UriKind.Relative), cancellationToken);
        }

        public virtual async Task<ApiResponse<TResult>> GetAsync<TResult>(Uri relativeUri,
            CancellationToken cancellationToken = default)
        {
            return await RequestHandler.HandleAsync<TResult>(() => GetAsync(relativeUri, cancellationToken));
        }

        public virtual async Task<ApiResponse<TResult>> PostAsync<TResult>(string uri, object content,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await PostAsync<TResult>(new Uri(uri, UriKind.Relative), content, cancellationToken);
        }

        public virtual async Task<ApiResponse<TResult>> PostAsync<TResult>(Uri relativeUri, object content,
            CancellationToken cancellationToken = default)
        {
            return await RequestHandler.HandleAsync<TResult>(() => PostAsync(relativeUri, 
                content.ToStringContent(), cancellationToken));
        }

        public virtual async Task<ApiResponse<TResult>> PutAsync<TResult>(string uri, object content,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await PutAsync<TResult>(new Uri(uri, UriKind.Relative), content, cancellationToken);
        }

        public virtual async Task<ApiResponse<TResult>> PutAsync<TResult>(Uri relativeUri, object content,
            CancellationToken cancellationToken = default)
        {
            return await RequestHandler.HandleAsync<TResult>(() => PutAsync(relativeUri, 
                content.ToStringContent(), cancellationToken));
        }

        public virtual async Task<ApiResponse<TResult>> DeleteAsync<TResult>(string uri,
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await DeleteAsync<TResult>(uri, cancellationToken);
        }

        public virtual async Task<ApiResponse<TResult>> DeleteAsync<TResult>(Uri relativeUri,
            CancellationToken cancellationToken = default)
        {
            return await RequestHandler.HandleAsync<TResult>(() => DeleteAsync(relativeUri, cancellationToken));
        }

        public void UseHeaders(IDictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void OverrideHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Remove(header.Key);
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
