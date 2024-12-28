using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        
        /// <summary>
        /// Get a list of tasks.
        /// </summary>
        /// <returns>A list of tasks.</returns>
        /// <response code="200">Returns list of tasks</response>
        /// <response code="404">The list of tasks are not founded.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
        {
            try
            {
                List<Tarefa> tarefas = await _tarefaRepository.GetAllTarefas();

                if (tarefas.IsNullOrEmpty())
                {
                    return NotFound(new { message = "Task list not found." });
                }

                return Ok(tarefas);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to list all tasks." });
            }

        }

        /// <summary>
        /// Get a task for id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific task.</returns>
        /// <response code="200">Returns the task.</response>
        /// <response code="404">The task is not founded.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tarefa>> GetTarefaById(long id)
        {
            try
            {
               Tarefa tarefa = await _tarefaRepository.GetById(id);

               if (tarefa == null)
               {
                    return NotFound(new { message = $"Task with id={id} not found." });
               }

                return Ok(tarefa);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {message = "Not found task using this ID."});
            }
        }

        /// <summary>
        /// Create a task.
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns>Created task.</returns>
        /// <response code="201">Returns the newly created task.</response>
        /// <response code="400">If the task is null.</response>
        /// <response code="409">The task has been created.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tarefa>> CreateTask([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest(new { message = "The datas submitted is invalid." });
            }

            try
            {
                Tarefa tarefas = await _tarefaRepository.Create(tarefa);
                return Created();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to create a task." });
            }
        }

        /// <summary>
        /// Updates a task has been created.
        /// </summary>
        /// <param name="tarefa"></param>
        /// <param name="id"></param>
        /// <returns>A task has been updated.</returns>
        /// <response code="200">The task was update successfully.</response>
        /// <response code="204">The task was updated, but no content.</response>
        /// <response code="400">The datas is invalid.</response>
        /// <response code="404">The task is not founded.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tarefa>> Update([FromBody] Tarefa tarefa,long id)
        {
            try
            {
                Tarefa tarefaAtualizada = await _tarefaRepository.Update(tarefa, id);
                return Ok(tarefaAtualizada);
            }catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to update this task." });
            }

        }

        /// <summary>
        /// Deletes a specific task.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The task has been deleted successfully.</response>
        /// <response code="404">Task not founded.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tarefa>> Delete(long id)
        {
            try
            {
                bool apagado = await _tarefaRepository.Delete(id);
                return Ok(apagado);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error to delete this task." });
            }
        }
    }
}
