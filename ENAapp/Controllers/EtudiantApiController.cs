using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class EtudiantApiController : Controller
    {
        private IEtudiantRepository etudiantRepository;
        private IInscritRepository inscritRepository;

        public EtudiantApiController(IEtudiantRepository etudiantRepository, IInscritRepository inscritRepository)
        {
            this.etudiantRepository = etudiantRepository;
            this.inscritRepository = inscritRepository;
        }

        [HttpPost]
        public IEnumerable<Etudiant> profile([FromBody] Compte etudiant)
        {
            return this.etudiantRepository.Profile(etudiant.Matricule);
        }

        /* [HttpGet]
          public IQueryable pv()
          {
              return this.etudiantRepository.ProcessVerbale("15T2309");
          }*/
        [HttpPatch]
        public IQueryable pv([FromBody] Resultat resultat)
        {
            return this.etudiantRepository.PvNiveau1(resultat);
        }

        [HttpPut]
        public IQueryable GetInscrits([FromBody] Compte compte)
        {
            return this.inscritRepository.ParcoursEtudiant(compte.Matricule);
        }

      
    }
}