
using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Repositories;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TarefaDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
