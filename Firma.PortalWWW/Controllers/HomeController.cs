using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Start));
        }

        public IActionResult Start()
        {
            return View();
        }

        public IActionResult Zgloszenia()
        {
            return View();
        }

        public IActionResult Wiadomosci()
        {
            return View();
        }

        public IActionResult MojePolisy()
        {
            return View();
        }

        public IActionResult MojeOferty()
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
