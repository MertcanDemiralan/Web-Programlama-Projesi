using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProjesi.Data;
using WebProgramlamaProjesi.Models;

namespace WebProgramlamaProjesi.Controllers
{
    public class KategorisController : Controller
    {
        ApplicationDbContext _context;// = new FilmContext();

        public KategorisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kategoris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategoriler.ToListAsync());
        }

        // GET: Kategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            if (kategori.Filmler.Count() >= 1)
            {
                foreach (var film in _context.Filmler)
                {
                    foreach (var ktgr in film.Kategoriler)
                    {
                        if (ktgr.Id == id)
                        {
                            kategori.Filmler.Add(film);
                        }
                    }


                }
            }
            else
            {
            }
            return View(kategori);
        }

        // GET: Kategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kategori_Adı")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: Kategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: Kategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kategori_Adı")] Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriExists(kategori.Id))
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
            return View(kategori);
        }

        // GET: Kategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: Kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _context.Kategoriler.FindAsync(id);
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategoriler.Any(e => e.Id == id);
        }
    }
}
