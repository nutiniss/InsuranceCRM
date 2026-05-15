using Firma.Data.Data;
using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firma.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirmaContext _context;

        public HomeController(FirmaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Pulpit));
        }

        public async Task<IActionResult> Pulpit()
        {
            ViewData["Klienci"] = await _context.Klient.CountAsync();
            ViewData["Polisy"] = await _context.Polisa.CountAsync();
            ViewData["Oferty"] = await _context.Oferta.CountAsync();
            ViewData["Zgloszenia"] = await _context.Zgloszenie.CountAsync();
            ViewData["ZadaniaOtwarte"] = await _context.Zadanie.CountAsync(z => z.Status != "Zakończone");
            ViewData["WiadomosciNieprzeczytane"] = await _context.Wiadomosc.CountAsync(w => !w.CzyPrzeczytana);

            return View();
        }

        public IActionResult Obsluga()
        {
            return View();
        }

        public IActionResult Wiadomosci()
        {
            return RedirectToAction("Index", "Wiadomosc");
        }

        public IActionResult Polisy()
        {
            return RedirectToAction("Index", "Polisa");
        }

        public IActionResult Oferty()
        {
            return RedirectToAction("Index", "Oferta");
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
