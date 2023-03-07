using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;

namespace ControleVendas.Models
{
    public class ControleVendasContext : DbContext
    {

        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }
        public DbSet<ItemVendaModel> ItensVenda { get; set; }
        public DbSet<RelatorioModel> Relatorios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"server=localhost\; database=SistemaVendas; Trusted_Connection=True; trustservercertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
