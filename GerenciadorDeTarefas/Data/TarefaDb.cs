using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Data
{
    public class TarefaDb : DbContext
    {
        public TarefaDb(DbContextOptions<TarefaDb> options): base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
