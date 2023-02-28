using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using Microsoft.AspNetCore.Http;
using GerenciamentoVendas.Service.Controllers;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        [HttpGet]        
        public IActionResult Login(int? id)
        {
            //Para realizar o logout
            if (id!=null)
            {
                if (id==0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            //Fim

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var response = new LoginController();
                var loginOk = response.ValidarLogin(login);
                if (loginOk != null)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", loginOk.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", loginOk.Nome);
                    return RedirectToAction("Menu","Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou Senha são inválidos!";
                }
            }

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
