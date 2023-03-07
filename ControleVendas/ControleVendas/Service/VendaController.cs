using ControleVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleVendas.Service
{
    public class VendaController : Controller
    {
        private readonly IControleVendasContext _contextFactory;
        //Para atender o filtro do relatório
        public List<VendaModel> ListagemVendas(string DataDe, string DataAte)
        {
            return RetornarListagemVendas(DataDe, DataAte);
        }

        //Listagem Geral
        public List<VendaModel> ListagemVendas()
        {
            return RetornarListagemVendas("1900/01/01", "2200/01/01");
        }

        private List<VendaModel> RetornarListagemVendas(string DataDe, string DataAte)
        {
            List<VendaModel> lista = new List<VendaModel>();
            VendaModel item;
            DAL objDAL = new DAL();
            string sql = " select TOP 10 v1.id, v1.data, v1.total, v2.nome as vendedor, c.nome as cliente from " +
                         " venda v1 inner join vendedor v2 on v1.vendedor_id = v2.id inner join cliente c " +
                         " on v1.cliente_id = c.id " +
                         $" where v1.data >='{DataDe}' and v1.data <='{DataAte}' " +
                         " order by data, total";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendaModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Data = DateTime.Parse(dt.Rows[i]["data"].ToString()).ToString("dd/MM/yyyy"),
                    Total = double.Parse(dt.Rows[i]["total"].ToString()),
                    Cliente_Id = dt.Rows[i]["cliente"].ToString(),
                    Vendedor_Id = dt.Rows[i]["vendedor"].ToString()
                };
                lista.Add(item);
            }

            return lista;
        }

        public void Inserir(VendaModel venda)
        {
            DAL objDAL = new DAL();

            string dataVenda = DateTime.Now.Date.ToString("yyyy/MM/dd");

            string sql = "INSERT INTO VENDA(data, total, vendedor_id, cliente_id) " +
                $"VALUES('{dataVenda}',{venda.Total.ToString().Replace(",", ".")},{venda.Vendedor_Id},{venda.Cliente_Id})";
            objDAL.ExecutarComandoSQL(sql);

            //Recuperar o ID da venda
            sql = $"select id from venda where data='{dataVenda}' and vendedor_id={venda.Vendedor_Id} and cliente_id={venda.Cliente_Id} order by id desc limit 1";
            DataTable dt = objDAL.RetDataTable(sql);
            string id_venda = dt.Rows[0]["id"].ToString();

            //Deserializar o JSON da lista de produtos selecionados e gravá-los na tabela itens_venda
            List<ItemVendaModel> lista_produtos = JsonConvert.DeserializeObject<List<ItemVendaModel>>(venda.ListaProdutos);
            for (int i = 0; i < lista_produtos.Count; i++)
            {
                sql = "insert into itens_venda(venda_id, produto_id, qtde_produto, preco_produto) " +
                    $"values({id_venda},{lista_produtos[i].CodigoProduto.ToString()}," +
                    $"{lista_produtos[i].QtdeProduto.ToString()}," +
                    $"{lista_produtos[i].PrecoUnitario.ToString().Replace(",", ".")})";
                objDAL.ExecutarComandoSQL(sql);

                //Baixa o produto do estoque
                sql = " update produto " +
                      $" set quantidade_estoque = (quantidade_estoque - " + int.Parse(lista_produtos[i].QtdeProduto.ToString()) + ") " +
                      $" where id = {lista_produtos[i].CodigoProduto.ToString()}";
                objDAL.ExecutarComandoSQL(sql);
            }
        }


        public List<ClienteModel> RetornarListaClientes()
        {
            return new ClienteController().ListarTodosClientes();
        }

        public List<VendedorModel> RetornarListaVendedores()
        {
            return new VendedorController().ListarTodosVendedores();
        }

        public List<ProdutoModel> RetornarListaProdutos()
        {
            return new ControleVendas.Service.ProdutoController().ListarTodosProdutos();
        }
    }
}
