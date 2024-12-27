
using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository

    {
        private readonly TarefaDb _tarefaDb;
        public TarefaRepository(TarefaDb tarefaDb)
        {
            _tarefaDb = tarefaDb;
        }
        public async Task<List<Tarefa>> GetAllTarefas()
        {
            return await _tarefaDb.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<Tarefa> GetById(long id)
        {
            return await _tarefaDb.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            await _tarefaDb.Tarefas.AddAsync(tarefa);
            await _tarefaDb.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> Delete(long id)
        {
            Tarefa tarefaById = await GetById(id);

            if (tarefaById == null)
            {
                throw new Exception($"Tarefa para o id = {id}, não foi encontrado.");
            }

            _tarefaDb.Tarefas.Remove(tarefaById);
            await _tarefaDb.SaveChangesAsync();
            return true;
        }

        public async Task<Tarefa> Update(Tarefa tarefa, long id)
        {
            Tarefa tarefaById = await GetById(id);

            if (tarefaById == null)
            {
                throw new Exception($"Tarefa para o id = {id}, não foi encontrado.");
            }

            tarefaById.Title = tarefa.Title;
            tarefaById.Description = tarefa.Description;
            tarefaById.DateCreation = tarefa.DateCreation;
            tarefaById.Status = tarefa.Status;
            tarefaById.UsuarioId = tarefa.UsuarioId;

            _tarefaDb.Tarefas.Update(tarefaById);
            await _tarefaDb.SaveChangesAsync(); 
            return tarefaById;
        }
    }
}
