using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Project;
using Ekbatan.Services.Repositories;
using Ekbatan.ViewModels.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private EkbatanDbContext _db;
        public ProjectRepository(EkbatanDbContext db)
        {
            _db = db;
        }
    

        public List<Project> GetAllProjects()
        {
            return _db.Projects.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _db.Projects.Find(projectId);
        }

        public void Insert_Project(Project project)
        {
            _db.Projects.Add(project);
        }

        public void Update_Project(Project project)
        {
            _db.Entry(project).State = EntityState.Modified;
        }

        public void Delete_Project(Project project)
        {
            _db.Entry(project).State = EntityState.Deleted;
        }
        public void DeleteProjectById(int projectId)
        {
            var p = GetProjectById(projectId);
            Delete_Project(p);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public bool ProjectExists(int ProjectId)
        {
          
          return _db.Projects.Any(e => e.Project_ID == ProjectId);
            
        }

        public List<ShowProjectViewModel> GetProjectCounts()
        {
            return _db.Projects.Select(g => new ShowProjectViewModel()
            {
                Project_ID=g.Project_ID,
                Project_name=g.Project_name,
                ProjectCount=g.Melks.Count
            }).ToList();
        }
    }
}
