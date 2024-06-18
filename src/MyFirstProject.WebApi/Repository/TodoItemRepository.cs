using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.WebApi.Context;
using MyFirstProject.Shared.Models;

namespace MyFirstProject.WebApi.Repository { 

    public class TodoItemRepository: ITodoItemRepository
    {
        private readonly ILogger<TodoItemRepository> _logger;
        private readonly TodoItemContext _context;

        public TodoItemRepository(ILogger<TodoItemRepository> logger, TodoItemContext context)
        {
            //testes
            _logger = logger;
            _context = context;
        }

   
        public  ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            _logger.LogInformation("Method - GetTodoItems");
            return  _context.TodoItems.ToList();
        }
         

  
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            _logger.LogInformation("Method - GetTodoItem");
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            return todoItem;
        }

        //Add Delete method
     
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            _logger.LogInformation("Method - DeleteTodoItem");
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return null;
    
        }

    }
}
