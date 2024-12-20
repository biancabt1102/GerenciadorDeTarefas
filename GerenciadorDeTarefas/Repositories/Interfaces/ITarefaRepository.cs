using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> GetById(long id);
        Task<List<Tarefa>> GetAllTarefas();
        Task<Tarefa> Create(Tarefa tarefa);
        Task<bool> Delete(long id);
        Task<Tarefa> Update(Tarefa tarefa, long id);

    }
}
