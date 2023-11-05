using MovContainer.Models;

namespace MovContainer.Repository.Interface
{
    public interface IMovimentacaoRepository
    {
        IEnumerable<Movimentacao> Movimentacoes { get; }
    }
}
