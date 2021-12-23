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
    public class FilmKategoriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmKategoriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilmKategori
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FilmKategoriler.Include(f => f.Film).Include(f => f.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FilmKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmKategori = await _context.FilmKategoriler
                .Include(f => f.Film)
                .Include(f => f.Kategori)
                .FirstOrDefaultAsync(m => m.FilmKategoriId == id);
            if (filmKategori == null)
            {
                return NotFound();
            }

            return View(filmKategori);
        }

        // GET: FilmKategori/Create
        public IActionResult Create()
        {
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Aciklamasi");
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Kategori_Adi");
            return View();
        }

        // POST: FilmKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmKategoriId,KategoriId,FilmId")] FilmKategori filmKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Aciklamasi", filmKategori.FilmId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Kategori_Adi", filmKategori.KategoriId);
            return View(filmKategori);
        }

        // GET: FilmKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmKategori = await _context.FilmKategoriler.FindAsync(id);
            if (filmKategori == null)
            {
                return NotFound();
            }
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Aciklamasi", filmKategori.FilmId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Kategori_Adi", filmKategori.KategoriId);
            return View(filmKategori);
        }

        // POST: FilmKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmKategoriId,KategoriId,FilmId")] FilmKategori filmKategori)
        {
            if (id != filmKategori.FilmKategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmKategoriExists(filmKategori.FilmKategoriId))
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
            ViewData["FilmId"] = new SelectList(_context.Filmler, "FilmId", "Film_Aciklamasi", filmKategori.FilmId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Kategori_Adi", filmKategori.KategoriId);
            return View(filmKategori);
        }

        // GET: FilmKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmKategori = await _context.FilmKategoriler
                .Include(f => f.Film)
                .Include(f => f.Kategori)
                .FirstOrDefaultAsync(m => m.FilmKategoriId == id);
            if (filmKategori == null)
            {
                return NotFound();
            }

            return View(filmKategori);
        }

        // POST: FilmKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmKategori = await _context.FilmKategoriler.FindAsync(id);
            _context.FilmKategoriler.Remove(filmKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmKategoriExists(int id)
        {
            return _context.FilmKategoriler.Any(e => e.FilmKategoriId == id);
        }
    }
}
