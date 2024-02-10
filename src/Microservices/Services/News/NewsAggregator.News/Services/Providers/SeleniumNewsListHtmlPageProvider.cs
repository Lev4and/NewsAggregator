using OpenQA.Selenium;

namespace NewsAggregator.News.Services.Providers
{
    public class SeleniumNewsListHtmlPageProvider : INewsListHtmlPageProvider
    {
        private readonly IWebDriver _webDriver;

        public SeleniumNewsListHtmlPageProvider(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public Task<string> ProvideAsync(string url, CancellationToken cancellationToken = default)
        {
            _webDriver.Navigate().GoToUrl(url);

            return Task.FromResult(_webDriver.PageSource);
        }
    }
}
