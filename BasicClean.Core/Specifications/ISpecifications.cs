using BasicClean.Core.Enitties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicClean.Core.Specifications
{
    public interface ISpecifications<T> where T : class
    {
        Expression<Func<T, bool>> IsSatisfiedBy();
    }
}
