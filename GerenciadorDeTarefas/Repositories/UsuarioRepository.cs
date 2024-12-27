using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TarefaDb _context;

        public UsuarioRepository(TarefaDb context)
        {
            _context = context;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Delete(long id)
        {
            Usuario usuarioId = await GetUserById(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário de Id = {id}, não foi encontrado.");
            }

            _context.Usuarios.Remove(usuarioId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Usuario>> GetAllUsers()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUserById(long id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> Update(Usuario usuario, long id)
        {
            Usuario usuarioId = await GetUserById(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário com o Id = {id} não foi encontrado");
            }

            usuarioId.Name = usuario.Name;
            usuarioId.Email = usuario.Email;

            _context.Usuarios.Update(usuarioId);
            await _context.SaveChangesAsync();
            return usuario;

        }
    }
}
