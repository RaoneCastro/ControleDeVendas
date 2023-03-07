using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;

namespace ControleVendas.Models
{
    public interface IControleVendasContext 
    {
        int SaveChanges();
        void ExecuteSqlCommand(string sql, params object[] parameters);
        IEnumerable<T> SqlQuery<T>(string sql, params SqlParameter[] parameters);
        IEnumerable<T> SqlQueryFormat<T>(string sql, params object[] parameters);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetCommandTimeout(int timeout);
        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }
        public DbSet<ItemVendaModel> ItensVenda { get; set; }
        public DbSet<RelatorioModel> Relatorios { get; set; }
        List<ClienteModel> ListarTodosClientes();
        List<VendedorModel> ListarTodosVendedores();
    }
}
