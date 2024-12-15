using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repositories
{
    public interface TarefaRepository
    {
        Task<Tarefa> GetById(long id);
        Task<Tarefa> GetAllTarefas();
        Task<Tarefa> CreateTarefa(Tarefa tarefa);
        Task<Tarefa> DeleteById(long id);
        Task<Tarefa> UpdateTarefa(long id);

    }
}
