using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using ControleVendas.Service;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            var context = new ControllerContext();

            var response = new ControleVendas.Service.ClienteController();

            ViewBag.ListaClientes = response.ListarTodosClientes();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {            
            if (id != null)
            {
                var response = new ControleVendas.Service.ClienteController();
                //Carregar o registro do cliente numa ViewBag
                ViewBag.Cliente = response.RetornarCliente(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {
            var response = new ControleVendas.Service.ClienteController();
            if (ModelState.IsValid)
            {
                response.Gravar(cliente);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirCliente(int id)
        {
            var response = new ControleVendas.Service.ClienteController();
            response.Excluir(id);

            return View();
        }
    }
}