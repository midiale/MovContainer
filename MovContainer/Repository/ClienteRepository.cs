using MovContainer.Context;
using MovContainer.Models;
using MovContainer.Repository.Interface;

namespace MovContainer.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Clientes => _context.Clientes;
    }
}
