using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Threading.Tasks;

namespace Ekbatan.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            string webRootPath = _environment.WebRootPath;
            string contentRootPath = _environment.ContentRootPath;
            string PathImg = webRootPath + "\\ImageSlider\\";
            string[] files = Directory.EnumerateFiles(PathImg, "*.*").Select(p => Path.GetFileName(p)).ToArray();

            ViewData.Model = files;
            return View();
        }
    }
}



