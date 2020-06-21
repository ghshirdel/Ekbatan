using System;
using System.Collections.Generic;
using System.Text;
using Ekbatan.DomainClasses.Project;
using Ekbatan.ViewModels.Project;

namespace Ekbatan.Services.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        void Insert_Project(Project project);
        void Update_Project(Project project);
        void Delete_Project(Project project);
        void DeleteProjectById(int projectId);
        void Save();
        bool ProjectExists(int ProjectId);
        List<ShowProjectViewModel> GetProjectCounts();
    }
}
