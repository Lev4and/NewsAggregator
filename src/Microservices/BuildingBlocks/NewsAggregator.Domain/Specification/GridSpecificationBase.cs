﻿using System.Linq.Expressions;

namespace NewsAggregator.Domain.Specification
{
    public abstract class GridSpecificationBase<T> : IGridSpecification<T>
    {
        public IEnumerable<Expression<Func<T, bool>>> Criterias { get; } = new List<Expression<Func<T, bool>>>();

        public IEnumerable<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public IEnumerable<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public Expression<Func<T, object>> GroupBy { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; set; }

        protected void ApplyIncludeList(IEnumerable<Expression<Func<T, object>>> includes)
        {
            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Append(includeExpression);
        }

        protected void ApplyIncludeList(IEnumerable<string> includes)
        {
            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }

        protected void AddInclude(string includeString)
        {
            IncludeStrings.Append(includeString);
        }

        protected IGridSpecification<T> ApplyFilterList(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            foreach (var filter in filters)
            {
                ApplyFilter(filter);
            }

            return this;
        }

        protected IGridSpecification<T> ApplyFilter(Expression<Func<T, bool>> expr)
        {
            Criterias.Append(expr);

            return this;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) 
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
