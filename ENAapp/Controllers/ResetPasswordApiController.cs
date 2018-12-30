using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Repositories;
using ENAapp.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class ResetPasswordApiController : ControllerBase
    {
        private readonly ICompteRepository compteRepository;

        private readonly IConfiguration Configuration;

        private readonly IEmailSender emailSender;

        public ResetPasswordApiController(ICompteRepository compteRepository,IConfiguration configuration,IEmailSender emailSender)
        {
            this.compteRepository = compteRepository;
            this.Configuration = configuration;
            this.emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (compte.Matricule == null || ! compteRepository.FindByMatricule(compte.Matricule))
            {
                ModelState.AddModelError("Matricule", "Matricule Invalide");
                return BadRequest(ModelState);
            }

            compte = compteRepository.FindByMatriculeAsync(compte.Matricule);

            var token = Hash.str_random(60);

            var id = compte.Id;

            compte.ResetToken = token;

            compte = compteRepository.UpdateAsync(compte);

            return Ok(compte);
        }

        [HttpPut]
        public async Task<IActionResult> SendEmail([FromBody] Compte compte)
        {

            compte = compteRepository.FindByEmailAsync(compte.Email);

            var token = Hash.str_random(60);
            var id = compte.Id;

            var callbackUrl = Url.Page(
                    "",
                    pageHandler: null,
                    values: new { id, token },
                    protocol: Request.Scheme);
            try
            {
                await emailSender.SendEmailAsync(
                compte.Email,
                "Reset Password",
                $"Please reset your password cliquer <a href='{HtmlEncoder.Default.Encode($"http://localhost:4200/confirm?id={id}&token={token}")}'>ici</a>.");
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("Email", "Echec D'envoie du  mail");
                return BadRequest(ModelState);
            }

            ModelState.AddModelError("Email", "Un mail a ete envoiyer a votre adresse ");
            return Ok(ModelState);

        }
        [HttpGet]
        public IActionResult ForgotPassword(string ide, string token)
        {
            int id =int.Parse(ide);
            if (id == 0 || token == null)
            {
                ModelState.AddModelError("ID", "Compte Inexistant ");
                return BadRequest(ModelState);
            }
            
            if (!compteRepository.CompteExists(id))
            {
                ModelState.AddModelError("Compte", "Impossible de charger votre compte ");
                return BadRequest(ModelState);
            }

            var user = compteRepository[id];


            if (!compteRepository.ConfirmateForgotPasswordAsync(user, token))
            {
                ModelState.AddModelError("Token", "Error confirming reset password for user with ID ");
                return BadRequest(ModelState);

            }

            HttpContext.Session.SetInt32("id", user.Id);

            ModelState.AddModelError("Status", "Okay");
            return BadRequest(ModelState);
        }

        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(Compte compte)
        //{
        //    if (compte.Id == 0 || !compteRepository.CompteExists(compte.Id))
        //    {
        //        ModelState.AddModelError("Compte", "Impossible de charger votre Utilisateur ");
        //        return BadRequest(ModelState);
        //    }

        //    var user =compteRepository[compte.Id];

        //    user.Passhash = compte.Passhash;

        //    user = compteRepository.UpdateAsync(user);

        //    ModelState.AddModelError("Status", "Mot de passe rinitialiser ");
        //    return BadRequest(ModelState);
        //}


    }
}