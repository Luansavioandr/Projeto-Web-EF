using Microsoft.AspNetCore.Mvc;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;
using Projeto_Web_EF.Models;
using Projeto_Web_EF.Negocio;
using System.Diagnostics;

namespace Projeto_Web_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFContexto _contexto;
        public HomeController(ILogger<HomeController> logger, EFContexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}