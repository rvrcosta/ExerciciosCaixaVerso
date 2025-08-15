using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApp.Data;

namespace ToDoApp.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ToDoDbContext _context;
        public TarefaController(ToDoDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index(bool? filtro)
        {
            var queryTarefas = _context.Tarefas.AsQueryable();
            if(filtro != null)
            {
                queryTarefas = queryTarefas.Where(t => t.StConcluida == filtro);
            }
            
            var tarefas = queryTarefas.ToList();

            List<SelectListItem> listaOpcoes = _context.Tarefas
                .Select(t => t.StConcluida)
                .Distinct()
                .Select(x => new SelectListItem
                {
                    Text = x ? "Concluído" : "Em Aberto",
                    Value = x.ToString(),
                    Selected = x == filtro
                }).ToList();

            listaOpcoes.Insert(0, new SelectListItem { Text = "Todos", Value = null, Selected = filtro == null });
            ViewBag.ListaOpcoes = listaOpcoes;
            ViewBag.StConcluido = filtro;

            return View(tarefas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                return View(tarefa);
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();
            
            var tarefa = _context.Tarefas.Find(id.Value);
            
            if(tarefa == null)
                return NotFound();

            return View(tarefa);
        }
        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (tarefa == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(tarefa);
            }

            _context.Update(tarefa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            return View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            _context.Remove(tarefa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult FinishTask(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            tarefa.StConcluida = true;
            _context.Update(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
