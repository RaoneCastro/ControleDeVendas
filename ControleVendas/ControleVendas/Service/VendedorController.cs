using ControleVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControleVendas.Service
{
    public class VendedorController : Controller
    {
        //private readonly IControleVendasContext _contextFactory;

        //public VendedorController(IControleVendasContext contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //}

        public List<VendedorModel> ListarTodosVendedores()
        {
            using(var db = new ControleVendasContext())
            {
                List<VendedorModel> lista = new List<VendedorModel>();

                return lista = db.Vendedores.ToList();
            }
        }

        public VendedorModel RetornarVendedor(int? id)
        {
            VendedorModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, email, senha FROM Vendedor where id ='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new VendedorModel
            {
                //Id = dt.Rows[0]["Id"].ToString(),
                //Nome = dt.Rows[0]["Nome"].ToString(),
                //Email = dt.Rows[0]["Email"].ToString(),
                //Senha = dt.Rows[0]["Senha"].ToString()
            };

            return item;
        }

        //INSERT OU UPDATE
        public void Gravar(VendedorModel vendedor)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (vendedor.Id != null)
            {
                sql = $"UPDATE VENDEDOR SET NOME='{vendedor.Nome}', EMAIL='{vendedor.Email}' where id = '{vendedor.Id}'";
            }
            else
            {
                sql = $"INSERT INTO VENDEDOR(NOME, EMAIL, SENHA) VALUES('{vendedor.Nome}','{vendedor.Email}','{vendedor.Senha}')";
            }

            objDAL.ExecutarComandoSQL(sql);
        }


        //DELETE
        public void VendedorExcluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM VENDEDOR WHERE ID='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
