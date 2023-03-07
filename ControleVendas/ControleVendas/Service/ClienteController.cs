using ControleVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControleVendas.Service
{
    public class ClienteController
    {
        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();

            using (var db = new ControleVendasContext())
            {
                lista = db.Clientes.ToList();

                return lista;
            }
        }

        //SELECT
        public ClienteModel RetornarCliente(int? id)
        {
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, cpf_cnpj, email, senha FROM Clientes where id ='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);
            
            item = new ClienteModel
            {
                //Id = dt.Rows[0]["Id"].ToString(),
                //Nome = dt.Rows[0]["Nome"].ToString(),
                //CPF = dt.Rows[0]["cpf_cnpj"].ToString(),
                //Email = dt.Rows[0]["Email"].ToString(),
                //Senha = dt.Rows[0]["Senha"].ToString()
            };
          
            return item;
        }

        //INSERT E UPDATE
        public void Gravar(ClienteModel cliente)
        {
            using (var db = new ControleVendasContext())
            {
                var clienteExistente = db.Clientes.FirstOrDefault(x => x.Id == cliente.Id);

                if (clienteExistente == null)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                }
                else
                {
                    clienteExistente = cliente;
                    db.SaveChanges();

                }
            }
            //DAL objDAL = new DAL();
            //string sql = string.Empty;

            //if (cliente.Id != null)
            //{
            //    sql = $"UPDATE CLIENTE SET NOME='{cliente.Nome}', CPF_CNPJ='{cliente.CPF}', EMAIL='{cliente.Email}' where id = '{cliente.Id}'";
            //}
            //else
            //{
            //    sql = $"INSERT INTO CLIENTE(NOME, CPF_CNPJ, EMAIL, SENHA) VALUES('{cliente.Nome}','{cliente.CPF}','{cliente.Email}','{cliente.Senha}')";
            //}

            //objDAL.ExecutarComandoSQL(sql);
        }


        //DELETE
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM CLIENTES WHERE ID='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
