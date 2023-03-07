using ControleVendas.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GerenciamentoVendas.Service.Controllers
{
    public class LoginController
    {
        public LoginModel ValidarLogin(LoginModel model)
        {
            using(var db = new ControleVendasContext())
            {
                var usuarioLogin = db.Vendedores.FirstOrDefault(x => x.Email == model.Email && x.Senha == model.Senha);

                if (usuarioLogin != null)
                {
                    model.Id = usuarioLogin.Id;
                    model.Nome = usuarioLogin.Nome;
                    return model;
                }
                else
                {
                    return model;
                }
            }
        }
    }
}
