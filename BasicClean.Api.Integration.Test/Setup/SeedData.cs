using BasicClean.Core.Enitties;
using BasicClean.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Api.Integration.Test.Setup
{
   public class SeedData
    {
        public static void Todos(TodoDbContext todoDbContext)
        {
            var todo = Todo.Create("First title", "first content");
            //todo.ChangeStatus(Core.ValueObjects.TodoStatus.InProgress);
            todoDbContext.Todos.Add(todo);
            todoDbContext.Todos.Add(Todo.Create("First title", "first content"));
            todoDbContext.SaveChanges();
        }
      
    }
}
