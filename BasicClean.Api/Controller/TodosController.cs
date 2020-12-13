
using BasicClean.Core.Dtos;
using BasicClean.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BasicClean.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var todos = _todoService.AllTodos();
            return Ok(todos);
        }
        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> Get(Guid id)
        {
            var todoItem = await _todoService.GetTodoById(id);
            if (todoItem is null) return NotFound();

            return Ok(todoItem);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTodoRequestDto createTodo)
        {
            var todo = _todoService.CreteTodo(createTodo);
            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }


    }
}
