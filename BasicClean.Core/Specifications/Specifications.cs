using System;
using System.Linq.Expressions;

namespace BasicClean.Core.Specifications
{
    public abstract class Specification<T> where T : class
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity) => ToExpression().Compile().Invoke(entity);

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

    }

    public sealed class AndSpecification<T> : Specification<T> where T :class
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
            throw new NotImplementedException();
        }
    }

    public class OrSpecification<T> : Specification<T> where T : class
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
            throw new NotImplementedException();
        }
    }
}
