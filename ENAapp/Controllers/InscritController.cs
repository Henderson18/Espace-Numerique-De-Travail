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
  
    public class InscritController : Controller
    {
        private IInscritRepository inscritRepository;
        private IVueRepository vueRepository;

        public InscritController(IInscritRepository inscritRepository,IVueRepository vueRepository)
        {
            this.inscritRepository = inscritRepository;
            this.vueRepository = vueRepository;
         }

        [HttpPost]
        public IQueryable ListInscription([FromBody] Compte compte)
        {
            return this.inscritRepository.InscriptionEtudiant(compte);
        }

        [HttpPut]
        public IQueryable DetailAnnee([FromBody] Moyennes moy)
        {
            return this.inscritRepository.DetailParcours(moy);
        }
        [HttpPatch]
        public IQueryable GetModule([FromBody] Compte compte)
        {
            return this.vueRepository.getVue(compte.Profil);
        }
    }
}