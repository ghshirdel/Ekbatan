using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses;
using Ekbatan.Services.Repositories;
using Ekbatan.DomainClasses.Project;
//using PagedList;
namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MelksController : Controller
    {
        private readonly EkbatanDbContext _context;
        private IProjectRepository projectRepository;
        private IMelkRepository melkRepository;
        public MelksController(EkbatanDbContext context,IProjectRepository _projectRepository,IMelkRepository _melkRepository)
        {
            _context = context;
            projectRepository = _projectRepository;
            melkRepository = _melkRepository;
        }
     
        // GET: Admin/Melks
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            ViewBag.CurrentFilter = searchString;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Project_name" : "";

            var qmelks = from m in _context.Melks select m;
            qmelks = _context.Melks.Include(m => m.FrontAge).Include(m => m.Karbari).Include(m => m.MelkPosition).Include(m => m.MelkType).Include(m => m.Project);

            if (!String.IsNullOrEmpty(searchString))
            {
                qmelks = _context.Melks.Where(m => m.Project.Project_name.Contains(searchString)
                                       || m.Address.Contains(searchString)
                                       || m.MelkType.TypeMelk_Desc.Contains(searchString)
                                       || m.PAsli.Contains(searchString)
                                       || m.PFarei.Contains(searchString)).Include(m => m.FrontAge).Include(m => m.Karbari).Include(m => m.MelkPosition).Include(m => m.MelkType).Include(m => m.Project);
            }
            switch (sortOrder)
            {
                case "Project_name":
                    qmelks = qmelks.OrderByDescending(s => s.Project);
                    break;
                case "Address":
                    qmelks = qmelks.OrderByDescending(s => s.Address);
                    break;
                case "MelkType":
                    qmelks = qmelks.OrderBy(m => m.MelkType);
                    break;
                case "PAsli":
                    qmelks = qmelks.OrderByDescending(m => m.PAsli);
                    break;  
                case "PFarei":
                    qmelks = qmelks.OrderByDescending(m => m.PFarei);
                    break;  
                case "MArseh":
                    qmelks = qmelks.OrderByDescending(m => m.MArseh);
                    break;
                case "MAyan":
                    qmelks = qmelks.OrderByDescending(m => m.MAyan);
                    break;
               default:
                    qmelks = qmelks.OrderBy(m => m.Address);
                    break;
            }

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            return View(qmelks);
        }
      
        // GET: Admin/Melks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melk = await _context.Melks
                .Include(m => m.FrontAge)
                .Include(m => m.Karbari)
                .Include(m => m.MelkPosition)
                .Include(m => m.MelkType)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Melk_ID == id);
            if (melk == null)
            {
                return NotFound();
            }

            return View(melk);
        }

        // GET: Admin/Melks/Create
        public IActionResult Create()
        {
            ViewData["FrontAge_ID"] = new SelectList(_context.FrontAges, "FrontAge_ID", "FrontAge_Desc");
            ViewData["Karbari_ID"] = new SelectList(_context.Karbaris, "Karbari_ID", "Karbari_Desc");
            ViewData["MelkPosition_ID"] = new SelectList(_context.MelkPositions, "MelkPosition_ID", "MelkPosition_Desc");
            ViewData["MelkType_ID"] = new SelectList(_context.MelkTypes, "MelkType_ID", "TypeMelk_Desc");
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_name");
            return View();
        }

        // POST: Admin/Melks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Melk_ID,Project_ID,MelkType_ID,Address,ShPosition,MelkPosition_ID,PAsli,PFarei,MArseh,MAyan,Karbari_ID,CFloor,NFloor,FrontAge_ID,Balkon,Anbari,MAnbari,Parking,Elevator,Contract_ID")] Melk melk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(melk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FrontAge_ID"] = new SelectList(_context.FrontAges, "FrontAge_ID", "FrontAge_Desc", melk.FrontAge_ID);
            ViewData["Karbari_ID"] = new SelectList(_context.Karbaris, "Karbari_ID", "Karbari_Desc", melk.Karbari_ID);
            ViewData["MelkPosition_ID"] = new SelectList(_context.MelkPositions, "MelkPosition_ID", "MelkPosition_Desc", melk.MelkPosition_ID);
            ViewData["MelkType_ID"] = new SelectList(_context.MelkTypes, "MelkType_ID", "TypeMelk_Desc", melk.MelkType_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_name", melk.Project_ID);
            return View(melk);
        }

        // GET: Admin/Melks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melk = await _context.Melks.FindAsync(id);
            if (melk == null)
            {
                return NotFound();
            }
            ViewData["FrontAge_ID"] = new SelectList(_context.FrontAges, "FrontAge_ID", "FrontAge_Desc", melk.FrontAge_ID);
            ViewData["Karbari_ID"] = new SelectList(_context.Karbaris, "Karbari_ID", "Karbari_Desc", melk.Karbari_ID);
            ViewData["MelkPosition_ID"] = new SelectList(_context.MelkPositions, "MelkPosition_ID", "MelkPosition_Desc", melk.MelkPosition_ID);
            ViewData["MelkType_ID"] = new SelectList(_context.MelkTypes, "MelkType_ID", "TypeMelk_Desc", melk.MelkType_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_name", melk.Project_ID);
            return View(melk);
        }

        // POST: Admin/Melks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Melk_ID,Project_ID,MelkType_ID,Address,ShPosition,MelkPosition_ID,PAsli,PFarei,MArseh,MAyan,Karbari_ID,CFloor,NFloor,FrontAge_ID,Balkon,Anbari,MAnbari,Parking,Elevator,Contract_ID")] Melk melk)
        {
            if (id != melk.Melk_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MelkExists(melk.Melk_ID))
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
            ViewData["FrontAge_ID"] = new SelectList(_context.FrontAges, "FrontAge_ID", "FrontAge_Desc", melk.FrontAge_ID);
            ViewData["Karbari_ID"] = new SelectList(_context.Karbaris, "Karbari_ID", "Karbari_Desc", melk.Karbari_ID);
            ViewData["MelkPosition_ID"] = new SelectList(_context.MelkPositions, "MelkPosition_ID", "MelkPosition_Desc", melk.MelkPosition_ID);
            ViewData["MelkType_ID"] = new SelectList(_context.MelkTypes, "MelkType_ID", "TypeMelk_Desc", melk.MelkType_ID);
            ViewData["Project_ID"] = new SelectList(_context.Projects, "Project_ID", "Project_name", melk.Project_ID);
            return View(melk);
        }

        // GET: Admin/Melks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melk = await _context.Melks
                .Include(m => m.FrontAge)
                .Include(m => m.Karbari)
                .Include(m => m.MelkPosition)
                .Include(m => m.MelkType)
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Melk_ID == id);
            if (melk == null)
            {
                return NotFound();
            }

            return View(melk);
        }

        // POST: Admin/Melks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var melk = await _context.Melks.FindAsync(id);
            _context.Melks.Remove(melk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MelkExists(int id)
        {
            return _context.Melks.Any(e => e.Melk_ID == id);
        }
    }
}
