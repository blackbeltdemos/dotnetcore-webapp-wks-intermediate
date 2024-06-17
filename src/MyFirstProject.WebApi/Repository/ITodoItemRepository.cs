using MyFirstProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.WebApi.Repository
{
    public interface ITodoItemRepository
    {

         ActionResult<IEnumerable<TodoItem>> GetTodoItems();

        Task<ActionResult<TodoItem>> GetTodoItem(long id);

         Task<IActionResult> DeleteTodoItem(long id);

    }
}
