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
    public class OyuncusController : Controller
    {
        ApplicationDbContext _context;// = new FilmContext();

        public OyuncusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oyuncus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oyuncular.ToListAsync());
        }

        // GET: Oyuncus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        // GET: Oyuncus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oyuncus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Fotografi")] Oyuncu oyuncu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oyuncu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oyuncu);
        }

        // GET: Oyuncus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular.FindAsync(id);
            if (oyuncu == null)
            {
                return NotFound();
            }
            return View(oyuncu);
        }

        // POST: Oyuncus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Fotografi")] Oyuncu oyuncu)
        {
            if (id != oyuncu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oyuncu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OyuncuExists(oyuncu.Id))
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
            return View(oyuncu);
        }

        // GET: Oyuncus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        // POST: Oyuncus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oyuncu = await _context.Oyuncular.FindAsync(id);
            _context.Oyuncular.Remove(oyuncu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OyuncuExists(int id)
        {
            return _context.Oyuncular.Any(e => e.Id == id);
        }
    }
}
