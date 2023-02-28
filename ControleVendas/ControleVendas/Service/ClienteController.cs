using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Collections.Generic;
using System.Data;

namespace ControleVendas.Service
{
    public class ClienteController
    {
        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM Cliente order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Senha = dt.Rows[i]["Senha"].ToString()
                };
                lista.Add(item);
            }

            return lista;
        }

        //SELECT
        public ClienteModel RetornarCliente(int? id)
        {
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, cpf_cnpj, email, senha FROM Cliente where id ='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);
            
            item = new ClienteModel
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                CPF = dt.Rows[0]["cpf_cnpj"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                Senha = dt.Rows[0]["Senha"].ToString()
            };
          
            return item;
        }

        //INSERT E UPDATE
        public void Gravar(ClienteModel cliente)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (cliente.Id != null)
            {
                sql = $"UPDATE CLIENTE SET NOME='{cliente.Nome}', CPF_CNPJ='{cliente.CPF}', EMAIL='{cliente.Email}' where id = '{cliente.Id}'";
            }
            else
            {
                sql = $"INSERT INTO CLIENTE(NOME, CPF_CNPJ, EMAIL, SENHA) VALUES('{cliente.Nome}','{cliente.CPF}','{cliente.Email}','{cliente.Senha}')";
            }

            objDAL.ExecutarComandoSQL(sql);
        }


        //DELETE
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM CLIENTE WHERE ID='{id}'";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
