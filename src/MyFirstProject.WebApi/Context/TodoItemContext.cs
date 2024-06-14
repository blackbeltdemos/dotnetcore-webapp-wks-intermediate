using Microsoft.EntityFrameworkCore;
using MyFirstProject.Shared.Models;

namespace MyFirstProject.WebApi.Context
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}