using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;

namespace ControleVendas.Models
{
    public class ControleVendasContext : DbContext
    {

        public ControleVendasContext(DbContextOptions<ControleVendasContext> options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"server=localhost\; database=SistemaVendas; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }

    }
}
