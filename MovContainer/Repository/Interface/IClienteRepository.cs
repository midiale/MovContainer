using MovContainer.Models;

namespace MovContainer.Repository.Interface
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }
    }
}
