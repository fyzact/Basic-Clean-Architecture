using System;
using System.Linq.Expressions;

namespace BasicClean.Core.Specifications
{
    public sealed class AndSpecification<T> : Specification<T> where T : class
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> left = _left.ToExpression();
            Expression<Func<T, bool>> right = _right.ToExpression();
            var leftInvokedExpression = Expression.Invoke(right, left.Parameters);
            var righInvokedExpression = Expression.Invoke(left, left.Parameters);
            return (Expression<Func<T, bool>>)Expression.Lambda(Expression.AndAlso(leftInvokedExpression, righInvokedExpression),left.Parameters);

        }
    }
}
