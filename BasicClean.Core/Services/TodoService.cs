using BasicClean.Core.Dtos;
using BasicClean.Core.Enitties;
using BasicClean.Core.Interfaces.Repositories;
using BasicClean.Core.Interfaces.Services;
using BasicClean.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Core.Services
{
    public class TodoService : ITodoService
    {
        IQueryRepository<Todo, Guid> _todoRepository;
        ICommandRepository<Todo, Guid> _todoCommandRepository;
        public TodoService(IQueryRepository<Todo, Guid> todoRepository, IQueryRepository<Todo, Guid> todoCommandRepository)
        {
            _todoRepository = todoRepository;
            _todoCommandRepository = todoCommandRepository;
        }
        public IEnumerable<TodoItemDto> AllTodos()
        {
            return _todoRepository.GetAll(new CreatedTodoSpecifications().And(new NonDeletedTodoSpecifications()).ToExpression()).ToList().Select(p => new TodoItemDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                State = p.State
            }).AsEnumerable();
        }

        public async Task<TodoItemDto> CreteTodo(CreateTodoRequestDto createTodo)
        {
            var todo = Todo.Create(createTodo.Title, createTodo.Content);
            await _todoCommandRepository.AddAsync(todo);
            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Content = todo.Content,
                State = todo.State
            };
        }

        public async Task<TodoItemDto> GetTodoById(Guid id)
        {
            var todo = await _todoRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
            if (todo is null) return null;

            var todoItem = new TodoItemDto { Content = todo.Content, Id = todo.Id, State = todo.State, Title = todo.Title };
            return todoItem;
        }
    }
}
