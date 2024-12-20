using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaDb _db;

        public TarefaController(TarefaDb db)
        {
            _db = db;
        }


        [HttpGet]
        public ActionResult<List<Tarefa>> GetAllTarefas()
        {
            return Ok();
        }

        //[HttpPost]
        //public ActionResult PostTask(Task task)
        //{
        //    return Ok(task);
        //}

        //[HttpPut]
        //public ActionResult PutTask(Task task)
        //{
        //    return Ok(task);
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    return Ok();
        //}
    }
}
