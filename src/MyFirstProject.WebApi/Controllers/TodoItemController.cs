using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.WebApi.Context;
using MyFirstProject.Shared.Models;
using MyFirstProject.WebApi.Repository;

namespace MyFirstProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ILogger<TodoItemController> _logger;
        private readonly ITodoItemRepository _repository;


        public TodoItemController(ILogger<TodoItemController> logger,  ITodoItemRepository repository)
        {
            //testes
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            _logger.LogInformation("Method - GetTodoItems");
            return _repository.GetTodoItems();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            _logger.LogInformation("Method - GetTodoItem");
            var todoItem = await _repository.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        //Add Delete method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            _logger.LogInformation("Method - DeleteTodoItem");
            var todoItem = await _repository.DeleteTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
