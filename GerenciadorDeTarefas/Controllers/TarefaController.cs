using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : Controller
    {
        //private readonly 
        public TarefaController() 
        {
            
        }

        [HttpGet]
        public ActionResult<List<Task>> GetAllTasks()
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
