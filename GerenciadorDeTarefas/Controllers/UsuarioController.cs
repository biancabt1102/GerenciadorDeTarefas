using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllUsers()
        {
            List<Usuario> usuarios = await _usuarioRepository.GetAllUsers();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsersById(long id)
        {
            Usuario usuario = await _usuarioRepository.GetUserById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuarioModel)
        {
            Usuario usuario = await _usuarioRepository.Create(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Update([FromBody] Usuario usuarioModel, long id)
        {
            usuarioModel.Id = id;
            Usuario usuario = await _usuarioRepository.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(long id)
        {
            bool apagado = await _usuarioRepository.Delete(id);
            return Ok(apagado);
        }
    }
}
