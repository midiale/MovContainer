using MovContainer.Context;
using MovContainer.Models;
using MovContainer.Repository.Interface;

namespace MovContainer.Repository
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly AppDbContext _context;

        public ContainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Container> Containers => _context.Containers;
                
    }
}
