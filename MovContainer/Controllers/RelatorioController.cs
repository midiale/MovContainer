using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovContainer.Context;
using MovContainer.Models;
using MovContainer.ViewModels;

namespace MovContainer.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Relatorio()
        {
            var exportacao = _context.Containers.Count(x => x.CategoriaSelcionada == Categoria.Importacao);
            var importacao = _context.Containers.Count(x => x.CategoriaSelcionada == Categoria.Exportacao);

            var relatorio = _context.Movimentacoes
            .Include(m => m.Container)
            .Include(m => m.Container.Cliente)
            .GroupBy(m => m.Container.Cliente.Empresa)
            .Select(g => new RelatorioViewModel
            {
                Empresa = g.Key,
                TiposMovimentacao = g.GroupBy(m => m.MovimentacaoSelecionada)
                    .Select(t => new TipoMovimentacaoViewModel
                    {
                        TipoMovimentacao = t.Key.ToString(),
                        TotalMovimentacoes = t.Count()
                    })
                    .ToList()
            })
            .ToList();

            ViewBag.Importacao = importacao;
            ViewBag.Exportacao = exportacao;


            return View(relatorio);

        }

    }
}
