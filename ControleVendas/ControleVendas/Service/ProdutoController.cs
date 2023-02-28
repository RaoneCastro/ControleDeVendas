using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Collections.Generic;
using System.Data;

namespace ControleVendas.Service
{
    public class ProdutoController : Controller
    {

        public List<ProdutoModel> ListarTodosProdutos()
        {
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Descricao = dt.Rows[i]["Descricao"].ToString(),
                    Preco_Unitario = decimal.Parse(dt.Rows[i]["preco_unitario"].ToString()),
                    Quantidade_Estoque = decimal.Parse(dt.Rows[i]["quantidade_estoque"].ToString()),
                    Unidade_Medida = dt.Rows[i]["unidade_medida"].ToString(),
                    Link_Foto = dt.Rows[i]["link_foto"].ToString()
                };
                lista.Add(item);
            }

            return lista;
        }

        public ProdutoModel RetornarProduto(int? id)
        {
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto where id ='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ProdutoModel
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                Descricao = dt.Rows[0]["Descricao"].ToString(),
                Preco_Unitario = decimal.Parse(dt.Rows[0]["preco_unitario"].ToString()),
                Quantidade_Estoque = decimal.Parse(dt.Rows[0]["quantidade_estoque"].ToString()),
                Unidade_Medida = dt.Rows[0]["unidade_medida"].ToString(),
                Link_Foto = dt.Rows[0]["link_foto"].ToString()
            };

            return item;
        }

        //INSERT OU UPDATE
        public void Gravar(ProdutoModel produto)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (produto.Id != null)
            {
                sql = $"UPDATE PRODUTO SET " +
                    $"NOME='{produto.Nome}', " +
                    $"DESCRICAO='{produto.Descricao}', " +
                    $"preco_unitario={produto.Preco_Unitario.ToString().Replace(",", ".")}, " +
                    $"quantidade_estoque='{produto.Quantidade_Estoque}', " +
                    $"unidade_medida='{produto.Unidade_Medida}', " +
                    $"link_foto='{produto.Link_Foto}' " +
                    $"where id = '{produto.Id}'";
            }
            else
            {
                sql = "INSERT INTO PRODUTO(NOME, DESCRICAO,preco_unitario,quantidade_estoque,unidade_medida,link_foto) " +
                     $"VALUES('{produto.Nome}', " +
                     $"'{produto.Descricao}'," +
                     $"'{produto.Preco_Unitario}'," +
                     $"'{produto.Quantidade_Estoque}'," +
                     $"'{produto.Unidade_Medida}'," +
                     $"'{produto.Link_Foto}')";
            }

            objDAL.ExecutarComandoSQL(sql);
        }

        //DELETE
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM PRODUTO WHERE ID='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
