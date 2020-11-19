using BasicClean.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Core.Interfaces.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItemDto> AllTodos();

    }
}
