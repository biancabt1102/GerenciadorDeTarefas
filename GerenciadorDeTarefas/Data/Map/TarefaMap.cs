using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DateCreation).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);
        }
    }
}
