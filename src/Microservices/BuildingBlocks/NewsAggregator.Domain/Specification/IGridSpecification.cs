using System.Linq.Expressions;

namespace NewsAggregator.Domain.Specification
{
    public interface IGridSpecification<T> : IRootSpecification
    {
        List<Expression<Func<T, bool>>> Criterias { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        List<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> GroupBy { get; }

        long Take { get; }

        long Skip { get; }

        bool IsPagingEnabled { get; set; }
    }
}
