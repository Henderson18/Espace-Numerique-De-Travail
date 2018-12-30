using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Repositories;
using ENAapp.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class LoginApiController : Controller
    {

        private ICompteRepository compteRepository;

        public LoginApiController(ICompteRepository compteRepository)
        {
            this.compteRepository = compteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Authentification([FromBody] Compte compte)
        {
            Compte current = new Compte();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!compteRepository.FindByMatricule(compte.Matricule))
            {
                ModelState.AddModelError("Matricule", "Ce matricule ne possède pas de compte");
                return BadRequest(ModelState);
            }
            //compte.Passhash = Hash.getHash(compte.Passhash);
            current =  compteRepository.Find(compte.Matricule);
            if (current.ConfirmatAt == null)
            {

                ModelState.AddModelError("Compte", "Ce compte doit être confirme");

                return BadRequest(ModelState);
            }

            if (!Hash.Equal(compte.Passhash, current.Passhash))
            {
                ModelState.AddModelError("Passhash", "Mot de passe incorrect");
                return BadRequest(ModelState);
            }
            current.Status = 1;
           // Compte cpt;

            current = compteRepository.UpdateAsync(current);

            HttpContext.Session.SetString("compte", JsonConvert.SerializeObject(current));
            // recherche vue (current.statut)

            return Ok(current);
        }

        [HttpPut]
        public Boolean Deconnexion([FromBody] Compte compte)
        {
            Compte compe = this.getSession();

            if (compte != null)
            {

                compte = compteRepository[compte.Id];
                compte.Status = 0;
                this.compteRepository.UpdateAsync(compte);
                HttpContext.Session.Remove("compte");
                return true;
            }
            return false;
        }

        [HttpGet]
        public Compte getSession()
        {
            Compte compte = null;
            string stringcompte = HttpContext.Session.GetString("compte");


            if (stringcompte != null)
            {
                compte = JsonConvert.DeserializeObject<Compte>(stringcompte);
            }

            return compte;
        }



    }
}