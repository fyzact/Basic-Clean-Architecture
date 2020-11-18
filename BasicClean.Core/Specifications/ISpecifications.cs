using BasicClean.Core.Enitties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicClean.Core.Specifications
{
    public abstract class Specification<T> where T : class
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity) => ToExpression().Compile().Invoke(entity);

    }
}
