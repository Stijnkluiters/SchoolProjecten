using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context, IHttpContextAccessor httpContext)
        {
            _httpAccessor = httpContext;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.partijen = this._context.Partij.ToList();
            ViewBag.dagen = Enum.GetValues(typeof(Dagen));
            var contextPlayerList = this._context.Player.ToList();
            var sessionPlayerlist = Player.GetRecentlyAddedPlayers(_httpAccessor);

            contextPlayerList.ForEach(
                p => p.isRecentlyAdded = 
                    (sessionPlayerlist.FirstOrDefault(_p => p.Id == _p.Id) != null)
            );
            ViewBag.players = contextPlayerList;

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
