using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Repositories;
using ENAapp.utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        IHostingEnvironment _hostingEnvironment;

        private readonly IFileService _repository;
        private readonly ICompteRepository _repositoryCompte;
        private readonly IEmailSender _emailSender;

        public ImportController(IEmailSender emailSender,IHostingEnvironment hostingEnvironment, IFileService repository,ICompteRepository repositoryCompte)
        {
            _hostingEnvironment = hostingEnvironment;
            _repository = repository;
            _repositoryCompte = repositoryCompte;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import([FromQuery] IFormFile model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            IFormFile excelfile = HttpContext.Request.Form.Files[0];


            if (!_repository.Lenght(excelfile))
            {
                ModelState.AddModelError("Name", "mauvaise taille du fichier");

                return View();
            }

            if (!_repository.IsExcell(excelfile))
            {
                ModelState.AddModelError("Name", "Importer les fichier de d'extension xlsx");

                return View();
            }

            _repository.SaveFile(_hostingEnvironment, excelfile);



            string newPath = Path.Combine(_hostingEnvironment.WebRootPath, "upload");

            var path = Path.Combine(newPath, excelfile.FileName);

            string[] head = _repository.Head(path);

            if(head.Length!= 2)
            {
                ModelState.AddModelError("Name", $"Une ou plusieurs colonnes en plus !");

                return View();
            }

            if (!head.Contains("matricule") && !head.Contains("email"))
            {
                ModelState.AddModelError("Name", "La colone matricule  ou email n'as pas été trouvé !");

                return View();
            }
            
            List<Compte> comptes = _repository.GetCompteInFile(path);

            //parcour pour insertion dans la base de donnés
            foreach (var compte in comptes)
            {
                if (!_repositoryCompte.FindEtudiant(compte.Matricule))
                {
                    ModelState.AddModelError("Matricule", $"Matricule Incorrecte {compte.Matricule}");

                    //continue;

                    return BadRequest(ModelState);
                }

                if (_repositoryCompte.FindByMatricule(compte.Matricule))
                {
                    ModelState.AddModelError("Matricule", $"Ce matricule possède deja un compte {compte.Matricule}");

                    //continue;

                    return BadRequest(ModelState);
                }
                if (_repositoryCompte.FindByEmail(compte.Email) || Regex.Match(compte.Email, "/^[a-z0-9._-]+@[a-z0-9._-]+\\.[a-z]{2,6}$/").Success)
                {
                    ModelState.AddModelError("email", "Email non valide");

                    //continue;

                    return BadRequest(ModelState);
                }

                var pass = compte.Passhash;

                compte.Passhash = Hash.GetHash(compte.Passhash);
                compte.Profil = 1;

               Compte  c =  _repositoryCompte.Add(compte);

               await  _emailSender.SendEmailAsync(
                   c.Email,
                   "Confirmation De Compte",
                   $"S'il vous plait confirmer votre compte <a href='localhost:5000/Comptes/Create?id={c.Id}&token={c.ConfirmationToken}'>ici</a>.<br/>" +
                   $"<hr/><p>matricule : {c.Matricule}</p>"+
                   $"<hr/><p>matricule : {pass}</p>"
                   );
            }

            return Ok(comptes.Count);
        }
    }
}