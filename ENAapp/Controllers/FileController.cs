using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        private ICompteRepository compteRepository;

        public FileController(IHostingEnvironment hostingEnvironment,ICompteRepository compteRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            this.compteRepository = compteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet] public  string Home()
        {
            return "anderson";
        }

        [HttpPost]
        public async Task<IActionResult> SetImage(IFormFile file, [FromQuery] string matricule)
        {
            Compte cpte = new Compte();
            

            cpte = this.compteRepository.Find(matricule);
            file = HttpContext.Request.Form.Files[0];

            if (file.Length == 0)
            {
                ModelState.AddModelError("ImgSrc", "mauvaise taille du fichier");
                ViewBag.error = "mauvaise taille du fichier";
                return BadRequest(ModelState);
            }
            string name = file.FileName;
            string folderName = "A://Angular/ENT/img";

            string newPath = Path.Combine(_hostingEnvironment.WebRootPath, folderName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            string sFileExtension = Path.GetExtension(file.FileName).ToLower();

            string fullPath = Path.Combine(newPath, name + sFileExtension);

           cpte.Imgsrc = name + sFileExtension;
         
           
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
             
                file.CopyTo(stream);
                this.compteRepository.UpdateAsync(cpte);

            }

            return Ok(cpte);
        }
    }
}