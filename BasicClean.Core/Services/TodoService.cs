using BasicClean.Core.Dtos;
using BasicClean.Core.Enitties;
using BasicClean.Core.Interfaces.Repositories;
using BasicClean.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicClean.Core.Services
{
    public class TodoService : ITodoService
    {
        IQueryRepository<Todo, Guid> _todoRepository;
        public TodoService(IQueryRepository<Todo,Guid> todoRepository)
        {
            _todoRepository = todoRepository;
        }
       public IEnumerable<TodoItemDto> AllTodos()
        {
            return _todoRepository.GetAll().ToList().Select(p => new TodoItemDto
            {
                Id=p.Id,
                Title=p.Title,
                Content=p.Content,
                State=p.State
            }).AsEnumerable();
        }
    }
}
