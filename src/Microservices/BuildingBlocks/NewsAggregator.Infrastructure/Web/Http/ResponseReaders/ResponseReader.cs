namespace NewsAggregator.Infrastructure.Web.Http.ResponseReaders
{
    public class ResponseReader : IResponseReader
    {
        public async Task<string> ReadAsync(HttpResponseMessage response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
