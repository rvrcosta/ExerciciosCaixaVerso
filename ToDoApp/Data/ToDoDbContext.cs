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

        internal void SeedDatabase()
        {
            if(!Tarefas.Any())
            {
                Tarefas.AddRange(
                    new Tarefa { NoTarefa = "Estudar C#",NoDescricao="Revisar as aulas da Ada.", StConcluida = true, DtEvento = new DateTime(2025,8,16), DtPrevisaoFinalizacao = new DateTime(2025,8,17)},
                    new Tarefa { NoTarefa = "Fazer exercício de Programação", NoDescricao = "Realizar o exercício de um CRUD para treinar como funciona o MVC.", StConcluida = true, DtEvento = new DateTime(2025, 8, 14),DtPrevisaoFinalizacao= new DateTime(2025, 8, 16) },
                    new Tarefa { NoTarefa = "Relaxar no Domingo", NoDescricao = "Também faz parte o descanso, relaxe no domingo.", StConcluida = false, DtEvento = new DateTime(2025, 8, 17) }
                );
                SaveChanges();
            }
        }
    }
}
