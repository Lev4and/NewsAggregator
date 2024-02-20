using NewsAggregator.Domain.Specification;
using System.Linq.Expressions;

namespace NewsAggregator.News.Specifications
{
    public class GetNewsSpecification : SpecificationBase<Entities.News>
    {
        public GetNewsSpecification(Expression<Func<Entities.News, bool>> criteria)
        {
            ApplyFilter(criteria);
        }
    }
}
