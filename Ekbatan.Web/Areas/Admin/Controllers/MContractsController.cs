using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MContract;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MContractsController : Controller
    {
        private readonly EkbatanDbContext _context;

        public MContractsController(EkbatanDbContext context)
        {
            _context = context;
            
        }

        // GET: Admin/MContracts
        public async Task<IActionResult> Index()
        {
            // qmelks = _context.Melks.Include(m => m.FrontAge).Include(m => m.Karbari).Include(m => m.MelkPosition).Include(m => m.MelkType).Include(m => m.Project);


            return View(await _context.MContracts.ToListAsync());
        }

        // GET: Admin/MContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContract = await _context.MContracts
                .FirstOrDefaultAsync(m => m.Contract_ID == id);
            if (mContract == null)
            {
                return NotFound();
            }

            return View(mContract);
        }

        // GET: Admin/MContracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contract_ID,Contract_No,Contract_Date,Mel_ID")] MContract mContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mContract);
        }

        // GET: Admin/MContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContract = await _context.MContracts.FindAsync(id);
            if (mContract == null)
            {
                return NotFound();
            }
            return View(mContract);
        }

        // POST: Admin/MContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Contract_ID,Contract_No,Contract_Date,Mel_ID")] MContract mContract)
        {
            if (id != mContract.Contract_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MContractExists(mContract.Contract_ID))
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
            return View(mContract);
        }

        // GET: Admin/MContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mContract = await _context.MContracts
                .FirstOrDefaultAsync(m => m.Contract_ID == id);
            if (mContract == null)
            {
                return NotFound();
            }

            return View(mContract);
        }

        // POST: Admin/MContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mContract = await _context.MContracts.FindAsync(id);
            _context.MContracts.Remove(mContract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MContractExists(int id)
        {
            return _context.MContracts.Any(e => e.Contract_ID == id);
        }
    }
}
