using System;
using System.Linq.Expressions;

namespace BasicClean.Core.Specifications
{
    public sealed class OrSpecification<T> : Specification<T> where T : class
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }


        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> left = _left.ToExpression();
            Expression<Func<T, bool>> right = _right.ToExpression();
            return ((Expression<Func<T, bool>>)Expression.Lambda(Expression.Or(right, left)));
        }
    }
}
