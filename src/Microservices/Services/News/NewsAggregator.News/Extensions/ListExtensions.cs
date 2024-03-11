using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Extensions
{
    public static class ListExtensions
    {
        public static List<NewsSourceTag> ToNewsSourceTags(this List<string> list)
        {
            return list
                .Select(item =>
                    new NewsSourceTag
                    {
                        Tag = new NewsTag
                        {
                            Name = item
                        }
                    })
                .ToList();
        }
    }
}
