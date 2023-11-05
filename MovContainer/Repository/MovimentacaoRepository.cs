using MovContainer.Context;
using MovContainer.Models;
using MovContainer.Repository.Interface;

namespace MovContainer.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movimentacao> Movimentacoes => _context.Movimentacoes;

    }
}
