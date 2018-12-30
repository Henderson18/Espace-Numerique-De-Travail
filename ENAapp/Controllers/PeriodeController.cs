 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.entity;
using ENAapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class PeriodeController : Controller
    {
        readonly IPeriodeRepository repository;
        readonly ITimeRepository timeRepository;
        public PeriodeController(
             IPeriodeRepository repository,
             ITimeRepository timeRepository
            )
        {
            this.repository = repository;
            this.timeRepository = timeRepository;
        }



       /* [HttpGet("classe/{idClasse}")]
        public IEnumerable<Periode> PeriodesOfClasse(int idClasse) => timeRepository.PeriodesOfClasse(idClasse);*/

        [HttpGet("salle/{idSalle}")]
        public IEnumerable<Periode> PeriodesOfSalle(int idSalle) => timeRepository.PeriodesOfSalle(idSalle);

        /*[HttpGet("enseignant/{idEnseignant}")]
        public IEnumerable<Periode> PeriodesOfEnseignant(string idEnseignant) => timeRepository.PeriodesOfEnseignant(idEnseignant);*/

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Periode periode)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("periode", "Ce format de periode est invalide");

                return BadRequest(ModelState);
            }

            ModelPeriode modelPeriode = new ModelPeriode();
            modelPeriode.SetModelPeriode(periode, new Jour());

            foreach (var p in repository.List())
            {
                ModelPeriode model = new ModelPeriode();
                model.SetModelPeriode(p, new Jour());

                if (modelPeriode.OverLap(model))
                {
                    ModelState.AddModelError("periode", $"Cette periode chevauche la periode {model.Debut.Hour}h{model.Debut.Minute} à {model.Fin.Hour}h{model.Fin.Minute}");

                    return BadRequest(ModelState);
                }
            }

            periode = repository.Save(periode);

            return Ok(periode);
        }
    }
}