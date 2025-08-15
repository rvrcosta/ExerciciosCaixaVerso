using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data
{
    public class ToDoDbContext : DbContext
    {
        protected ToDoDbContext()
        {
        }
    }
}
