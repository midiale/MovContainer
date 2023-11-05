using MovContainer.Models;

namespace MovContainer.Repository.Interface
{
    public interface IContainerRepository
    {
        IEnumerable<Container> Containers { get; }
    }

    
}
