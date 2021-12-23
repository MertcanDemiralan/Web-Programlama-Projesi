using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OMDb.Data;
using OMDb.Models;

namespace OMDb.Controllers
{
    public class YorumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YorumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yorum
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yorumlar.Include(y => y.Film);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ShowAdminYorums()
        {
            return View(await _context.Yorumlar.ToListAsync());
        }
        // GET: Films
        public async Task<IActionResult> ShowYorums(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yorumlar = (from yorum in _context.Yorumlar
                            where yorum.FilmId == id
                            select yorum).ToList();
            //var yorumlar = await _context.Yorumlar
            //    .Include(y => y.Film)
            //     //_context.Filmler
            //     .FirstOrDefaultAsync(m => m.FilmId == id);
            if (yorumlar == null)
            {
                return NotFound();
            }
            return View(yorumlar);
            //await _context.Yorumlar.ToListAsync();
        }
        // GET: Yorum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorumlar
                .Include(y => y.Film)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorum/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Aciklamasi");
            return View();
        }

        // POST: Yorum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YorumId,Text,FilmId")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                yorum.FilmId = (int)TempData["FilmId"];
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowYorums), new { id = yorum.FilmId });
            }
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Adi", yorum.FilmId);
            return View(yorum);
        }

        // GET: Yorum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorumlar.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Adi", yorum.FilmId);
            return View(yorum);
        }

        // POST: Yorum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YorumId,Text,FilmId")] Yorum yorum)
        {
            if (id != yorum.YorumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.YorumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Adi", yorum.FilmId);
            return View(yorum);
        }

        // GET: Yorum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorumlar
                .Include(y => y.Film)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorum = await _context.Yorumlar.FindAsync(id);
            _context.Yorumlar.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.Yorumlar.Any(e => e.YorumId == id);
        }
    }
}
