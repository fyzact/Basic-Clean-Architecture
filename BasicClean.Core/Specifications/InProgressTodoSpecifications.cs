using BasicClean.Core.Enitties;
using BasicClean.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicClean.Core.Specifications
{
    public class InProgressTodoSpecifications: ISpecifications<Todo>
    {
        public Expression<Func<Todo, bool>> IsSatisfiedBy()
        {
            return p => p.IsDeleted == false && p.State == TodoState.InProgress;
        }
    }
}
