using BasicClean.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Core.Interfaces.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItemDto> AllTodos();
        Task<TodoItemDto> GetTodoById(Guid id);

        TodoItemDto CreteTodo(CreateTodoRequestDto createTodo);


    }
}
