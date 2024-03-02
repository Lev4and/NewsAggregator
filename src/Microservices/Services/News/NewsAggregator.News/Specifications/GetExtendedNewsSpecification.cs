using System.Linq.Expressions;

namespace NewsAggregator.News.Specifications
{
    public class GetExtendedNewsSpecification : GetNewsSpecification
    {
        public GetExtendedNewsSpecification(Expression<Func<Entities.News, bool>> criteria) : base(criteria)
        {
            AddInclude(news => news.Editor);
            AddInclude(news => news.Editor.Source);
            AddInclude(news => news.Editor.Source.Logo);
            AddInclude(news => news.SubTitle);
            AddInclude(news => news.HtmlDescription);
            AddInclude(news => news.TextDescription);
            AddInclude(news => news.Picture);
            AddInclude(news => news.Video);
        }
    }
}
