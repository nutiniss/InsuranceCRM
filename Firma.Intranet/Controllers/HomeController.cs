using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.Intranet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Pulpit));
        }

        public IActionResult Pulpit()
        {
            return View();
        }

        public IActionResult Obsluga()
        {
            return View();
        }

        public IActionResult Wiadomosci()
        {
            return View();
        }

        public IActionResult Polisy()
        {
            return View();
        }

        public IActionResult Oferty()
        {
            return View();
        }

        public IActionResult Administracja()
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
