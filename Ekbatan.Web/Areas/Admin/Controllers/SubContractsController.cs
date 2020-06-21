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
    public class SubContractsController : Controller
    {
        private readonly EkbatanDbContext _context;

        public SubContractsController(EkbatanDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SubContracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubContracts.ToListAsync());
        }

        // GET: Admin/SubContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subContract = await _context.SubContracts
                .FirstOrDefaultAsync(m => m.SubContract_ID == id);
            if (subContract == null)
            {
                return NotFound();
            }

            return View(subContract);
        }

        // GET: Admin/SubContracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SubContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubContract_ID,Melk_ID,Customer_ID,Sahm")] SubContract subContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subContract);
        }

        // GET: Admin/SubContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subContract = await _context.SubContracts.FindAsync(id);
            if (subContract == null)
            {
                return NotFound();
            }
            return View(subContract);
        }

        // POST: Admin/SubContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubContract_ID,Melk_ID,Customer_ID,Sahm")] SubContract subContract)
        {
            if (id != subContract.SubContract_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubContractExists(subContract.SubContract_ID))
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
            return View(subContract);
        }

        // GET: Admin/SubContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subContract = await _context.SubContracts
                .FirstOrDefaultAsync(m => m.SubContract_ID == id);
            if (subContract == null)
            {
                return NotFound();
            }

            return View(subContract);
        }

        // POST: Admin/SubContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subContract = await _context.SubContracts.FindAsync(id);
            _context.SubContracts.Remove(subContract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubContractExists(int id)
        {
            return _context.SubContracts.Any(e => e.SubContract_ID == id);
        }
    }
}
