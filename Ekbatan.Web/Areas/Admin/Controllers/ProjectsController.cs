using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Project;
using Ekbatan.Services.Repositories;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Builder;
using MD.PersianDateTime.Standard;

namespace Ekbatan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        IProjectRepository projectRepository;
            public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;    
        }
        // GET: Admin/Projects
        public async Task<IActionResult> Index()
        {
            //IFormatProvider culture = new System.Globalization.CultureInfo("fa-IR", true);
            //   IFormatProvider PersianCulture = culture
          var persianDateTimeNow = PersianDateTime.Now;
           persianDateTimeNow.PersianNumber = true;

            return View(projectRepository.GetAllProjects());
        }

       

        // GET: Admin/Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = projectRepository.GetProjectById(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Admin/Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Project_ID,Project_name,Parv_Date,PStart_Date,PEnd_Date,Payan_Date")] Project project)
        {
            if (ModelState.IsValid)
            {
                projectRepository.Insert_Project(project);
                projectRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Admin/Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = projectRepository.GetProjectById(id.Value);
            if (project == null)
            {
                
                return NotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Project_ID,Project_name,Parv_Date,PStart_Date,PEnd_Date,Payan_Date")] Project project)
        {
            if (id != project.Project_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    projectRepository.Update_Project(project);
                    projectRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Project_ID))
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
            return View(project);
        }

        // GET: Admin/Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = projectRepository.GetProjectById(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = projectRepository.GetProjectById(id);
            projectRepository.Delete_Project(project);
            projectRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return projectRepository.ProjectExists(id);
        }
    }
}
