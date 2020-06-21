using Ekbatan.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekbatan.Web.ViewComponents
{
    public class ShowProjectComponent: ViewComponent
    {
        IProjectRepository projectRepository;
        public ShowProjectComponent(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()       
        {
            return await Task.FromResult((IViewComponentResult)
                View("ShowProjectComponent", projectRepository.GetProjectCounts()));
        }
    }
}
