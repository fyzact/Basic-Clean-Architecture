using BasicClean.Core.Enitties;
using BasicClean.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BasicClean.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoService _todoService;
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
    }
}
