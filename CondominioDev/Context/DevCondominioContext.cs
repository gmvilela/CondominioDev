using CondominioDev.Models;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Context
{
    public class DevCondominioContext : DbContext
    {

        public DevCondominioContext() { }

        public DevCondominioContext(DbContextOptions<DevCondominioContext> options) : base(options) { }

        public DbSet<Despesas> Despesas { get; set; }
        public DbSet<Habitante> Habitantes { get; set; }
        public DbSet<Receitas> Receitas { get; set; }

    }
}
