using StackExchange.Redis;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace NewsAggregator.Infrastructure.Web.Http.Builders
{
    internal class HttpClientHandlerBuilder
    {
        private readonly HttpClientHandler _httpClientHandler;

        public HttpClientHandlerBuilder()
        {
            _httpClientHandler = new HttpClientHandler();
        }

        public HttpClientHandlerBuilder UseSslProtocols()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            return this;
        }

        public HttpClientHandlerBuilder UseCertificateCustomValidation()
        {
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            return this;
        }

        public HttpClientHandlerBuilder UseCertificate(byte[] data)
        {
            _httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            _httpClientHandler.ClientCertificates.Add(new X509Certificate2(data));

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
