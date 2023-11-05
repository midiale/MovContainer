using Microsoft.EntityFrameworkCore;
using MovContainer.Models;

namespace MovContainer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<Movimentacao> Movimentacoes { get; set; }

    }
}
