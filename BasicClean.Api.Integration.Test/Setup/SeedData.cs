using BasicClean.Core.Enitties;
using BasicClean.Infrastructure;
using System.Linq;

namespace BasicClean.Api.Integration.Test.Setup
{
    public class SeedData
    {
        public static void Todos(TodoDbContext todoDbContext)
        {
            var todo = Todo.Create("First title", "first content");
            //todo.ChangeStatus(Core.ValueObjects.TodoStatus.InProgress);
            todoDbContext.Todos.Add(todo);
            var todo2 = Todo.Create("Second title", "second content");
            todoDbContext.Todos.Add(todo2);
            todoDbContext.SaveChanges();
            var lıst = todoDbContext.Todos.ToList();
        }
      
    }
}
