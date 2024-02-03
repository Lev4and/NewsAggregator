using System.Linq.Expressions;

namespace NewsAggregator.Domain.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> _left, Expression<Func<T, bool>> _right)
        {
            var parameters = _left.Parameters[0];

            var visitor = new SubstExpressionVisitor();

            visitor._subst[_right.Parameters[0]] = parameters;

            Expression body = Expression.And(_left.Body, visitor.Visit(_right.Body));

            return Expression.Lambda<Func<T, bool>>(body, parameters);
        }

        private class SubstExpressionVisitor : ExpressionVisitor
        {
            public readonly Dictionary<Expression, Expression> _subst = new();

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _subst.TryGetValue(node, out var newValue) ? newValue : node;
            }
        }
    }
}
