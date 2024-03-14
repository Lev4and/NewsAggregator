using StackExchange.Redis;
using System.Net;

namespace NewsAggregator.Infrastructure.Web.Http.Builders
{
    internal class HttpClientHandlerBuilder
    {
        private readonly HttpClientHandler _httpClientHandler;

        public HttpClientHandlerBuilder()
        {
            _httpClientHandler = new HttpClientHandler();

            _httpClientHandler.UseProxy = true;
            _httpClientHandler.UseDefaultCredentials = true;
        }

        public HttpClientHandlerBuilder UseSslProtocols()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            return this;
        }

        public HttpClientHandlerBuilder UseCertificateCustomValidation()
        {
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            return this;
        }

        public HttpClientHandlerBuilder WithAllowAutoRedirect()
        {
            _httpClientHandler.AllowAutoRedirect = true;

            return this;
        }

        public HttpClientHandlerBuilder WithAutomaticDecompression()
        {
            _httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate |
                DecompressionMethods.Brotli;

            return this;
        }

        public HttpClientHandler Build()
        {
            return _httpClientHandler;
        }
    }
}
