using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.FrontAge;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FrontAgesController : Controller
    {
        private readonly EkbatanDbContext _context;

        public FrontAgesController(EkbatanDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FrontAges
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrontAges.ToListAsync());
        }

        // GET: Admin/FrontAges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontAge = await _context.FrontAges
                .FirstOrDefaultAsync(m => m.FrontAge_ID == id);
            if (frontAge == null)
            {
                return NotFound();
            }

            return View(frontAge);
        }

        // GET: Admin/FrontAges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FrontAges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrontAge_ID,FrontAge_Desc")] FrontAge frontAge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frontAge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frontAge);
        }

        // GET: Admin/FrontAges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontAge = await _context.FrontAges.FindAsync(id);
            if (frontAge == null)
            {
                return NotFound();
            }
            return View(frontAge);
        }

        // POST: Admin/FrontAges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrontAge_ID,FrontAge_Desc")] FrontAge frontAge)
        {
            if (id != frontAge.FrontAge_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frontAge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrontAgeExists(frontAge.FrontAge_ID))
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
            return View(frontAge);
        }

        // GET: Admin/FrontAges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontAge = await _context.FrontAges
                .FirstOrDefaultAsync(m => m.FrontAge_ID == id);
            if (frontAge == null)
            {
                return NotFound();
            }

            return View(frontAge);
        }

        // POST: Admin/FrontAges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frontAge = await _context.FrontAges.FindAsync(id);
            _context.FrontAges.Remove(frontAge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrontAgeExists(int id)
        {
            return _context.FrontAges.Any(e => e.FrontAge_ID == id);
        }
    }
}
