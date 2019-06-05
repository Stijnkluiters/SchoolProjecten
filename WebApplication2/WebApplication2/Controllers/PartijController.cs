using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PartijController : Controller
    {
        private readonly DatabaseContext _context;

        public PartijController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Partij
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partij.ToListAsync());
        }

        // GET: Players/CreateSpecial?playerId=1&day=Saturday
        public IActionResult CreateSpecial(int playerId, Dagen day)
        {
            if(playerId <= 0)
            {
                return NotFound();
            }
            Player player = this._context.Player.FirstOrDefault(p => p.Id == playerId);
            if(player == null)
            {
                return NotFound();
            }
            Partij partij = new Partij() { Player = player, PlayerId = player.Id, Dag = day };
            ViewBag.Uitslagen = Enum.GetValues(typeof(Uitslagen));
            return View(partij);
        }
        // GET: Partij/Create
        public IActionResult Create()
        {
            ViewBag.Players = _context.Player.ToList();
            ViewBag.Dagen = Enum.GetValues(typeof(Dagen));
            ViewBag.Uitslagen = Enum.GetValues(typeof(Uitslagen));
            return View();
        }

        // POST: Partij/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Partij partij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(partij);
        }
    }
}
