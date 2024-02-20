﻿using System.Linq.Expressions;

namespace NewsAggregator.Domain.Specification
{
    public interface ISpecification<T> : IRootSpecification
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        List<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> GroupBy { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}
