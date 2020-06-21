using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MelkPosition;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MelkPositionsController : Controller
    {
        private readonly EkbatanDbContext _context;

        public MelkPositionsController(EkbatanDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MelkPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.MelkPositions.ToListAsync());
        }

        // GET: Admin/MelkPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkPosition = await _context.MelkPositions
                .FirstOrDefaultAsync(m => m.MelkPosition_ID == id);
            if (melkPosition == null)
            {
                return NotFound();
            }

            return View(melkPosition);
        }

        // GET: Admin/MelkPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MelkPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MelkPosition_ID,MelkPosition_Desc")] MelkPosition melkPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melkPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(melkPosition);
        }

        // GET: Admin/MelkPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkPosition = await _context.MelkPositions.FindAsync(id);
            if (melkPosition == null)
            {
                return NotFound();
            }
            return View(melkPosition);
        }

        // POST: Admin/MelkPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MelkPosition_ID,MelkPosition_Desc")] MelkPosition melkPosition)
        {
            if (id != melkPosition.MelkPosition_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melkPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MelkPositionExists(melkPosition.MelkPosition_ID))
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
            return View(melkPosition);
        }

        // GET: Admin/MelkPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkPosition = await _context.MelkPositions
                .FirstOrDefaultAsync(m => m.MelkPosition_ID == id);
            if (melkPosition == null)
            {
                return NotFound();
            }

            return View(melkPosition);
        }

        // POST: Admin/MelkPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var melkPosition = await _context.MelkPositions.FindAsync(id);
            _context.MelkPositions.Remove(melkPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MelkPositionExists(int id)
        {
            return _context.MelkPositions.Any(e => e.MelkPosition_ID == id);
        }
    }
}
