using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;

namespace ControleVendas.Controllers
{
    public class VendedorController : Controller
    {
     
        public IActionResult Index()
        {
            ViewBag.ListaVendedores = new ControleVendas.Service.VendedorController().ListarTodosVendedores();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar o registro do vendedor numa ViewBag
                ViewBag.Vendedor = new ControleVendas.Service.VendedorController().RetornarVendedor(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedor)
        {
            if (ModelState.IsValid)
            {
                new ControleVendas.Service.VendedorController().Gravar(vendedor);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirVendedor(int id)
        {
            new ControleVendas.Service.VendedorController().VendedorExcluir(id);
            return View();
        }
    }
}