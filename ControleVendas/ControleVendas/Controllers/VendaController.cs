using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using Microsoft.AspNetCore.Http;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        private IHttpContextAccessor httpContext;

        //Recebe o contexto HTTP via injeção de dependência
        public VendaController(IHttpContextAccessor HttpContextAccessor)
        {
            httpContext = HttpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListaVendas = new ControleVendas.Service.VendaController().ListagemVendas();
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            //captura o id do vendedor logado no sistema
            venda.Vendedor_Id = httpContext.HttpContext.Session.GetString("IdUsuarioLogado");

            new ControleVendas.Service.VendaController().Inserir(venda);
            CarregarDados();
            return View();
        }

        private void CarregarDados()
        {
            ViewBag.ListaClientes = new ControleVendas.Service.VendaController().RetornarListaClientes();
            ViewBag.ListaVendedores = new ControleVendas.Service.VendaController().RetornarListaVendedores();
            ViewBag.ListaProdutos = new ControleVendas.Service.VendaController().RetornarListaProdutos();
        }
    }
}