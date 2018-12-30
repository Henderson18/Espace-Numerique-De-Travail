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
    public class MoyenneApiController : Controller
    {
        private IMoyenneRepository moyenneRepository;

        public MoyenneApiController(IMoyenneRepository moyenneRepository)
        {
            this.moyenneRepository = moyenneRepository;
        }

        [HttpPost]
        public IQueryable ParcoursAnnee([FromBody] Moyennes moyennes)
        {
            return this.moyenneRepository.MoyenneEtudiantAnnee(moyennes.Matricule, moyennes.Idsemestre, moyennes.Annee);
        }
    }
}