using System.Data.Entity;

namespace LojaPcs.Models
{
    public class LojaPCsContext : DbContext
    {
        public LojaPCsContext() : base("strConn") {
             
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LojaPCsContext>());
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Fonte> Fontes { get; set; }

        public DbSet<Gabinete> Gabinetes { get; set; }

        public DbSet<GPU> GPUs { get; set; }

        public DbSet<HD> HDs { get; set; }

        public DbSet<PlacaMae> PlacaMaes { get; set; }

        public DbSet<Processador> Processadors { get; set; }

        public DbSet<Ram> Rams { get; set; }

        public DbSet<Computador> Computadores { get; set; }

        public DbSet<Venda> Vendas { get; set; }

    }
}
