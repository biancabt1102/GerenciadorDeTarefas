using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
        {
            List<Tarefa> tarefas = await _tarefaRepository.GetAllTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefaById(long id)
        {
           Tarefa tarefa = await _tarefaRepository.GetById(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> CreateTask([FromBody] Tarefa tarefa)
        {
            Tarefa tarefas = await _tarefaRepository.Create(tarefa);
            return Ok(tarefas);
        }

        [HttpPut]
        public async Task<ActionResult<Tarefa>> Update([FromBody] Tarefa tarefa,long id)
        {
            tarefa.Id = id;
            Tarefa tarefaAtualizada = await _tarefaRepository.Update(tarefa, id);
            return Ok(tarefaAtualizada);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefa>> Delete(long id)
        {
            bool apagado = await _tarefaRepository.Delete(id);
            return Ok(apagado);
        }
    }
}
