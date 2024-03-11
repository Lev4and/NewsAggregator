
using System.Linq.Expressions;

namespace NewsAggregator.News.Specifications
{
    public class GetLiteNewsSpecification : GetNewsSpecification
    {
        public GetLiteNewsSpecification(Expression<Func<Entities.News, bool>> criteria) : base(criteria)
        {
            AddInclude(news => news.Editor);
            AddInclude(news => news.Editor.Source);
            AddInclude(news => news.Editor.Source.Logo);
            AddInclude(news => news.Editor.Source.Tags);
        }
    }
}
