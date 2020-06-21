using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ekbatan.Web.Controllers
{
    public class upImage : Controller
    {
        private IHostingEnvironment _environment;

        public upImage(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        
        public IActionResult Index(ICollection<IFormFile> files)
        {
       
           return View();
        }

        [HttpPost]

        public async Task<IActionResult> UploadImage(ICollection<IFormFile> files)
        {

            var uploads = Path.Combine(_environment.WebRootPath, "ImageSlider");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}

    
