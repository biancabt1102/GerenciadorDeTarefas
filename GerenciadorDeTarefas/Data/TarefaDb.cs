using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Data
{
    public class TarefaDb : DbContext
    {
        public TarefaDb(DbContextOptions<TarefaDb> options): base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
