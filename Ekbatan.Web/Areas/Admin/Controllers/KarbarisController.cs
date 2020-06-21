using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Karbari;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KarbarisController : Controller
    {
        private readonly EkbatanDbContext _context;

        public KarbarisController(EkbatanDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Karbaris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Karbaris.ToListAsync());
        }

        // GET: Admin/Karbaris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karbari = await _context.Karbaris
                .FirstOrDefaultAsync(m => m.Karbari_ID == id);
            if (karbari == null)
            {
                return NotFound();
            }

            return View(karbari);
        }

        // GET: Admin/Karbaris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Karbaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Karbari_ID,Karbari_Desc")] Karbari karbari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karbari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karbari);
        }

        // GET: Admin/Karbaris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karbari = await _context.Karbaris.FindAsync(id);
            if (karbari == null)
            {
                return NotFound();
            }
            return View(karbari);
        }

        // POST: Admin/Karbaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Karbari_ID,Karbari_Desc")] Karbari karbari)
        {
            if (id != karbari.Karbari_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karbari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KarbariExists(karbari.Karbari_ID))
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
            return View(karbari);
        }

        // GET: Admin/Karbaris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karbari = await _context.Karbaris
                .FirstOrDefaultAsync(m => m.Karbari_ID == id);
            if (karbari == null)
            {
                return NotFound();
            }

            return View(karbari);
        }

        // POST: Admin/Karbaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karbari = await _context.Karbaris.FindAsync(id);
            _context.Karbaris.Remove(karbari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KarbariExists(int id)
        {
            return _context.Karbaris.Any(e => e.Karbari_ID == id);
        }
    }
}
