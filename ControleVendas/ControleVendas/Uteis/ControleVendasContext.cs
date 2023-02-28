using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using System.Reflection.Metadata;

namespace ControleVendas.Uteis
{
    public class ControleVendasContext : DbContext
    {
        
        public ControleVendasContext(DbContextOptions<ControleVendasContext> options)
        : base(options)
        {

        }

        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"server=localhost\; database=SistemaVendas; Trusted_Connection=True;");
        }
    }
}
