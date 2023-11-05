using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovContainer.Context;
using MovContainer.Models;

namespace MovContainer.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly AppDbContext _context;

        public MovimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MovimentacaoController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Movimentacoes.Include(x => x.Container).ToListAsync());
        }


        // GET: MovimentacaoController/Create
        public ActionResult Create()
        {
            ViewData["ContainerId"] = new SelectList
                    (_context.Containers, "ContainerId", "Numero");
            return View();
        }

        // POST: MovimentacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("MovimentacaoId," +
            "DataHoraInicio,DataHoraFim,ContainerId,Numero,MovimentacaoSelecionada")] Movimentacao movimentacao)

        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MovimentacaoId = new SelectList(_context.Movimentacoes, "ContainerId", "Numero", movimentacao.ContainerId);

            return View(movimentacao);
        }

        // GET: MovimentacaoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimentacoes == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(x => x.Container)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: MovimentacaoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimentacoes == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["ContainerId"] = new SelectList
                    (_context.Containers, "ContainerId", "Numero");
            return View(movimentacao);
        }

        // POST: MovimentacaoController/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovimentacaoId,ContainerId,MovimentacaoSelecionada," +
            "DataHoraInicio,DataHoraFim,Numero")] Movimentacao movimentacao)

        {
            if (id != movimentacao.MovimentacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.MovimentacaoId))
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
            ViewBag.ContainerId = new SelectList
                    (_context.Containers, "ContainerId", "Numero", movimentacao.ContainerId);
            return View(movimentacao);
        }

        // GET: MovimentacaoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimentacoes == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(x => x.Container)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: MovimentacaoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimentacoes == null)
            {
                return Problem("Entity set 'AppDbContext.Containers'  is null.");
            }
            var container = await _context.Movimentacoes.FindAsync(id);
            if (container != null)
            {
                _context.Movimentacoes.Remove(container);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.MovimentacaoId == id);
        }
    }
}
