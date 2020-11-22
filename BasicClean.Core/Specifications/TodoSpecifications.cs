using BasicClean.Core.Enitties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicClean.Core.Specifications
{
    public class NonDeletedTodoSpecifications : Specification<Todo>
    {
        public override Expression<Func<Todo, bool>> ToExpression()
        {
            return todo => todo.IsDeleted == false;
        }
    }

    public class CreatedTodoSpecifications : Specification<Todo>
    {
        public override Expression<Func<Todo, bool>> ToExpression()
        {
            return todo => todo.State == ValueObjects.TodoState.Created;
        }
    }
}
