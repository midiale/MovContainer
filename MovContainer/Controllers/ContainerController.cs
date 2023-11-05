using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovContainer.Context;
using MovContainer.Models;

namespace MovContainer.Controllers
{
    public class ContainerController : Controller
    {
        private readonly AppDbContext _context;

        public ContainerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContainerController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Containers.Include(x => x.Cliente).ToListAsync());
        }

        // GET: ContainerController/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList
                    (_context.Clientes, "ClienteId", "Empresa");
            return View();
        }

        // POST: ContainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("ContainerId,Numero,TipoSelecionado," +
            "StatusSelecionado,CategoriaSelcionada,ClienteId,Empresa")] Container container)
        {
            var confereCadastro = container.Numero;
            bool numeroJaExiste = _context.Containers.Any(c => c.Numero == confereCadastro);

            if (ModelState.IsValid)
            {
                if (numeroJaExiste)
                {

                    ModelState.AddModelError("Numero", "Container já cadastrado!");

                    container = new Container();
                    return View(container);
                }

                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoriaId = new SelectList(_context.Containers, "ClienteId", "Empresa", container.ClienteId);

            return View(container);
        }

        // GET: ContainerController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(m => m.ContainerId == id);

            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // GET:  ContainerController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList
                    (_context.Clientes, "ClienteId", "Empresa");

            return View(container);
        }

        // POST:  ContainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,ContainerId,Numero,TipoSelecionado," +
            "StatusSelecionado,CategoriaSelcionada")] Container container)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(container.ContainerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ClienteId = new SelectList
                    (_context.Clientes, "ClienteId", "Empresa", container.ClienteId);
            return View(container);
        }


        // GET: ContainerController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(m => m.ContainerId == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // POST: ContainerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Containers == null)
            {
                return Problem("Entity set 'AppDbContext.Containers'  is null.");
            }
            var container = await _context.Containers.FindAsync(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Containers.Any(e => e.ContainerId == id);
        }

    }

}
