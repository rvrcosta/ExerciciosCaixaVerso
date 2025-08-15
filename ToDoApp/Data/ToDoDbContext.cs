using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas => Set<Tarefa>();
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
           : base(options)
        {
        }
    }
}
