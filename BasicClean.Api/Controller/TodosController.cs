using BasicClean.Core.Enitties;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BasicClean.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
