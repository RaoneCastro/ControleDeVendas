using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Data;
using System.Data.SqlClient;

namespace GerenciamentoVendas.Service.Controllers
{
    public class LoginController
    {
        public LoginModel ValidarLogin(LoginModel model)
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL=@email AND SENHA=@senha";
            SqlCommand Command = new SqlCommand();
            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@email", model.Email);
            Command.Parameters.AddWithValue("@senha", model.Senha);

            DAL objDAL = new DAL();

            DataTable dt = objDAL.RetDataTable(Command);
            if (dt.Rows.Count == 1)
            {
                model.Id = dt.Rows[0]["ID"].ToString();
                model.Nome = dt.Rows[0]["NOME"].ToString();

                //login.Id = dt.Rows[0]["ID"].ToString();
                //login.Nome = dt.Rows[0]["NOME"].ToString();
                return model;
            }
            else
            {
                return model;
            }
        }
    }
}
