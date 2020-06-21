using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MelkType;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MelkTypesController : Controller
    {
        private readonly EkbatanDbContext _context;

        public MelkTypesController(EkbatanDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MelkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MelkTypes.ToListAsync());
        }

        // GET: Admin/MelkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkType = await _context.MelkTypes
                .FirstOrDefaultAsync(m => m.MelkType_ID == id);
            if (melkType == null)
            {
                return NotFound();
            }

            return View(melkType);
        }

        // GET: Admin/MelkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MelkTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MelkType_ID,TypeMelk_Desc")] MelkType melkType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melkType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(melkType);
        }

        // GET: Admin/MelkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkType = await _context.MelkTypes.FindAsync(id);
            if (melkType == null)
            {
                return NotFound();
            }
            return View(melkType);
        }

        // POST: Admin/MelkTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MelkType_ID,TypeMelk_Desc")] MelkType melkType)
        {
            if (id != melkType.MelkType_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melkType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MelkTypeExists(melkType.MelkType_ID))
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
            return View(melkType);
        }

        // GET: Admin/MelkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melkType = await _context.MelkTypes
                .FirstOrDefaultAsync(m => m.MelkType_ID == id);
            if (melkType == null)
            {
                return NotFound();
            }

            return View(melkType);
        }

        // POST: Admin/MelkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var melkType = await _context.MelkTypes.FindAsync(id);
            _context.MelkTypes.Remove(melkType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MelkTypeExists(int id)
        {
            return _context.MelkTypes.Any(e => e.MelkType_ID == id);
        }
    }
}
