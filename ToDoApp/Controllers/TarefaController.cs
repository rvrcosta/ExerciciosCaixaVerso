using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
