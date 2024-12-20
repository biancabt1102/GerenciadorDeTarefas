using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUserById(long id);
        Task<List<Usuario>> GetAllUsers();
        Task<Usuario> Create(Usuario usuario);
        Task<bool> Delete(long id);
        Task<Usuario> Update(Usuario usuario, long id);
    }
}
