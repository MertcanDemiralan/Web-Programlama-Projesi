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
    public class YorumsController : Controller
    {
        ApplicationDbContext _context;//= new FilmContext();

        public YorumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yorums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yorumlar.ToListAsync());
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorumlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yapan_Kullanici_Id,Yapilan_Film_Id,Yorum_Metni,Yildiz")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        // GET: Yorums/Edit/5
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
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yapan_Kullanici_Id,Yapilan_Film_Id,Yorum_Metni,Yildiz")] Yorum yorum)
        {
            if (id != yorum.Id)
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
                    if (!YorumExists(yorum.Id))
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
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorumlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorums/Delete/5
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
            return _context.Yorumlar.Any(e => e.Id == id);
        }
    }
}
