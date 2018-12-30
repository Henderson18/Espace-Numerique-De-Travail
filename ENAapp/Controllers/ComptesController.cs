using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ENT_Background.enumeration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ENAapp.Models;
using ENAapp.Filters;
using ENAapp.Repositories;
using ENAapp.utils;


namespace ENAapp.Controllers
{
    public class ComptesController : Controller
    {
        private readonly bd_entContext _context;

        private readonly ICompteRepository _repository;
        
        private readonly IConfiguration Configuration;

        private readonly IEmailSender _emailSender;


        
        public ComptesController(

            IEmailSender emailSender,
            bd_entContext context, ICompteRepository repository, 
            IConfiguration _Configuration

            )
        {
            _context = context;

            _repository = repository;

            Configuration = _Configuration;

            _emailSender = emailSender;
        }

        // GET: Comptes
        [IsAdmin]
        public async Task<IActionResult> Index()
        {
            var bd_entContext = _context.Compte.Include(c => c.MatriculeNavigation);
            return View(await bd_entContext.ToListAsync());
        }
       
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Compte compte)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
           
            if(!_repository.FindEtudiant(compte.Matricule))
            {
                ModelState.AddModelError("Matricule", "Ce matricule n'existe pas");

                return View();
            }

            if (_repository.FindByMatricule(compte.Matricule))
            {
                ModelState.AddModelError("Matricule", "Ce matricule possède déja un compte");

                return View();
            }

            if (_repository.FindByEmail(compte.Email))
            {
                ModelState.AddModelError("Email", "Cet email est déja utilisé");

                return View();
            }



            if(compte.Passhash == null || compte.Passhash.Length < 4)
            {
                ModelState.AddModelError("Passhash", "Ce mot de passe est  faible");
                return View();
            }
            var token = Hash.str_random(60);

            compte.Passhash = Hash.GetHash(compte.Passhash);

            compte.Profil = (int)Profil.ADMINISTRATEUR;

            compte.ConfirmationToken = token;

            compte = await _repository.SaveAysnc(compte);
            
            var id = compte.Id;

            var callbackUrl = Url.Page(
                    "",
                    pageHandler: null, 
                    values: new {id,token },
                    protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                   compte.Email,
                   "Confirmation De Compte",
                   $"S'il vous plait confirmer votre compte <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>ici</a>.<br/>" +
                   $"<hr/><p>matricule : {compte.Matricule}</p>"
                   );

            return RedirectToAction("Index", "Home");
            
        }

       [HttpGet]
       public IActionResult Create(int id, string token)
        {
            if(id == 0 || token == null)
            {
                return View();
            }

            if (!_repository.CompteExists(id))
            {
                return NotFound($"Unable to load user with ID '{id}'.");
            }

            var user =  _repository[id];

            if(!_repository.ConfirmEmailAsync(user, token))
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{id}':");
            }

            return RedirectToAction("Index");

        }
        
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(Compte compte)
        {
            
            if (compte.Matricule == null || !_repository.FindByMatricule(compte.Matricule))
            {
                ModelState.AddModelError("Matricule", "Matricule Invalide");
                return View();
            }

            compte = _repository.FindByMatriculeAsync(compte.Matricule);
           
            var token = Hash.str_random(60);
            var id = compte.Id;

            compte.ResetToken = token;

            compte =  _repository.UpdateAsync(compte);

            //HttpContext.Session.SetString("compte", JsonConvert.SerializeObject(compte));

            // return RedirectToAction(nameof(ConfirmResetPassword));
            return View("ConfirmResetPasswordPost", compte);
        }


        public IActionResult ConfirmResetPassword(int id, string token)
        {
            if (id == 0 || token == null)
            {
                // var stringcompte = HttpContext.Session.GetString("compte");

                // var c = JsonConvert.DeserializeObject<Compte>(stringcompte);

                //return View(c);
            }

            if (!_repository.CompteExists(id))
            {
                return NotFound("Unable to load user with ID .");
            }

            var user = _repository[id];


            if (!_repository.ConfirmateForgotPasswordAsync(user, token))
            {
                throw new InvalidOperationException($"Error confirming reset password for user with ID '{id}':");
            }

            HttpContext.Session.SetInt32("id", user.Id);

            return RedirectToAction("ResetPassword",user);
        }
        [HttpPost]
        public IActionResult ConfirmResetPasswordPost(Compte compte)
        {
            return View(compte);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmResetPassword(Compte compte)
        {
            //var stringcompte = HttpContext.Session.GetString("compte");

            //var compte = JsonConvert.DeserializeObject<Compte>(stringcompte);
            compte = _repository.FindByEmailAsync(compte.Email);

            var token = Hash.str_random(60);
            var id = compte.Id;

            var callbackUrl = Url.Page(
                    "",
                    pageHandler: null,
                    values: new { id, token },
                    protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                compte.Email,
                "Reset Password",
                $"Please reset your password cliquer <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>ici</a>.");

            //HttpContext.Session.Remove("compte");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword(int id, string token)
        {
            if (id == 0 || token == null)
            {
                return View();
            }

            if (!_repository.CompteExists(id))
            {
                return NotFound("Unable to load user with ID .");
            }

            var user = _repository[id];


            if (!_repository.ConfirmateForgotPasswordAsync(user, token))
            {
                throw new InvalidOperationException($"Error confirming reset password for user with ID '{id}':");
            }

            HttpContext.Session.SetInt32("id", user.Id);

            return RedirectToAction("ResetPassword");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

          //  var id = HttpContext.Session.GetInt32("id");

           // compte.Id = id ?? 0;

            if(compte.Id == 0 || !_repository.CompteExists(compte.Id))
            {
                return NotFound("Unable to load user with ID .");
            }

            var user = _repository[compte.Id];

            user.Passhash = compte.Passhash;

            user =  _repository.UpdateAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
