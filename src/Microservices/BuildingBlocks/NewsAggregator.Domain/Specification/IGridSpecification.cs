using System.Linq.Expressions;

namespace NewsAggregator.Domain.Specification
{
    public interface IGridSpecification<T> : IRootSpecification
    {
        IEnumerable<Expression<Func<T, bool>>> Criterias { get; }

        IEnumerable<Expression<Func<T, object>>> Includes { get; }

        IEnumerable<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> GroupBy { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; set; }
    }
}
