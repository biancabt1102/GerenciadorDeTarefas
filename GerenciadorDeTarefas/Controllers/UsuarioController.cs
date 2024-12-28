using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Get a list of users.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Return the list of user.</response>
        /// <response code="404">Not found the list</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Usuario>>> GetAllUsers()
        {
            try
            {
                List<Usuario> usuarios = await _usuarioRepository.GetAllUsers();
                if(usuarios.IsNullOrEmpty())
                {
                    return NotFound(new { message = "List of user not found." });
                }

                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to list all users." });
            }
        }

        /// <summary>
        /// Get the user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Return the user.</response>
        /// <response code="404">Not found the user.</response>
        /// <response code="500">Server error.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> GetUsersById(long id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.GetUserById(id);
                if (usuario == null)
                {
                    return NotFound(new {message = $"User id = {id} not found."});
                }

                return Ok(usuario);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to find the user." });
            }
        }

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        /// <response code="201">Create the user.</response>
        /// <response code="204">User created, but no content.</response>
        /// <response code="400">The data submitted is invalid.</response>
        /// <response code="409">Conflict between the users.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuarioModel)
        {
            if (usuarioModel == null)
            {
                return BadRequest(new {message="The data submitted is invalid"});
            }

            try
            {
                Usuario usuario = await _usuarioRepository.Create(usuarioModel);
                return Created($"api/usuario/{usuario.Id}",usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to create a user." });
            }
        }

        /// <summary>
        /// Update a user.
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">User updated.</response>
        /// <response code="204">The user was updated, but no content.</response>
        /// <response code="400">The datas submitted is invalid.</response>
        /// <response code="404">User not found to be updated.</response>
        /// <response code="500">Server error.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> Update([FromBody] Usuario usuarioModel, long id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.Update(usuarioModel, id);
                return Ok(usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to update the user." });
            }
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">User deleted successfully.</response>
        /// <response code="404">User not found to be deleted.</response>
        /// <response code="500">Server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> Delete(long id)
        {
            try
            {
                bool apagado = await _usuarioRepository.Delete(id);
                return Ok(apagado);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to deleted a user." });
            }
        }
    }
}
