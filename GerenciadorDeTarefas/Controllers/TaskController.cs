using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("[task]")]
    public class TaskController : Controller
    {
        //private readonly 
        public TaskController() 
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
