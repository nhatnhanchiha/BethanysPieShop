using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BethanysPieShop.Models;

namespace BethanysPieShop
{
    public class PiesController : Controller
    {
        private readonly AppDbContext _context;

        public PiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET:     
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pies.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PieId == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // GET: Pies/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PieId,Name,ShortDescription,LongDescription,AllergyInformation,Price,ImageUrl,ImageThumbnailUrl,IsPieOfTheWeek,InStock,CategoryId,Notes")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // GET: Pies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies.FindAsync(id);
            if (pie == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // POST: Pies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PieId,Name,ShortDescription,LongDescription,AllergyInformation,Price,ImageUrl,ImageThumbnailUrl,IsPieOfTheWeek,InStock,CategoryId,Notes")] Pie pie)
        {
            if (id != pie.PieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieExists(pie.PieId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // GET: Pies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PieId == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pie = await _context.Pies.FindAsync(id);
            _context.Pies.Remove(pie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieExists(int id)
        {
            return _context.Pies.Any(e => e.PieId == id);
        }
    }
}
