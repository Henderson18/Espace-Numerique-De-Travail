using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.entity;
using ENAapp.Models.Repositories;
using ENAapp.Models.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class TimeController : Controller
    {
        private ITimeRepository repository;
        private IPeriodeRepository periodeRepository;
        private IJourRepository jourRepository;
        private ISalleRepository salleRepository;
        private IProgrammeRepository programmeRepository;
        private IEnseignantRepository enseignantRepository;
        ITimeService service;

        public TimeController(
            ITimeRepository repository,
            IPeriodeRepository periodeRepository,
            IJourRepository jourRepository,
            ISalleRepository salleRepository,
            IProgrammeRepository programmeRepository,
            IEnseignantRepository enseignantRepository,
            ITimeService service
            )
        {
            this.repository = repository;
            this.periodeRepository = periodeRepository;
            this.jourRepository = jourRepository;
            this.salleRepository = salleRepository;
            this.programmeRepository = programmeRepository;
            this.enseignantRepository = enseignantRepository;
            this.service = service;
        }

        [HttpGet("classe/{idClasse}/{semestre}")]
        public IEnumerable<Time> TimeTableOfClasse(int idClasse, int semestre) => repository.TimeTableOfClasse(idClasse, semestre);

        [HttpGet("enseignant/{idEnseignant}/{semestre}")]
        public IEnumerable<Time> TimeTableOfEnseignant(string matriculeEnseignant, int semestre) => repository.TimeTableOfEnseignant(matriculeEnseignant, semestre);

        [HttpGet("salle/{idSalle}/{semestre}")]
        public IEnumerable<Time> TimeTableOfSalwle(int idSalle, int semestre) => repository.TimeTableOfSalle(idSalle, semestre);

        [HttpPost("{semestre}")]
        public async Task<IActionResult> Add([FromBody] Time time, int semestre)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("time", "formulaire invalide");

                return BadRequest(ModelState);
            }

            if (!periodeRepository.PeriodeExists(time.Idperiode))
            {
                ModelState.AddModelError("periode", "Cette periode n'existe pas");

                return BadRequest(ModelState);
            }

            if (!jourRepository.JourExists(time.Idjour))
            {
                ModelState.AddModelError("jour", "Ce jour n'existe pas");

                return BadRequest(ModelState);
            }

            if (!salleRepository.SalleExists(time.Idsalle))
            {
                ModelState.AddModelError("salle", "Cet salle n'existe pas");

                return BadRequest(ModelState);
            }

            if (!programmeRepository.ProgrammeExists(time.Idprogramme))
            {
                ModelState.AddModelError("programme", "Cet ue n'existe pas");

                return BadRequest(ModelState);
            }

            Periode periode = periodeRepository[time.Idperiode];
            Jour jour = jourRepository[time.Idjour];

            ModelPeriode modelPeriode = new ModelPeriode();
            modelPeriode.SetModelPeriode(periode, jour);

            Salle salle = salleRepository[time.Idsalle];
            Programme programme = programmeRepository[time.Idprogramme];
            Compte enseignant = enseignantRepository[programme.Enseignant];

            //verifion que la salle est libre

            foreach (var t in repository.TimeTableOfSalle(salle.Id, semestre))
            {
                Periode p = periodeRepository[t.Idperiode];
                Jour j = jourRepository[t.Idjour];

                ModelPeriode model = new ModelPeriode();
                model.SetModelPeriode(p, j);

                if (modelPeriode.OverLap(model))
                {
                    ModelState.AddModelError("salle", $"La salle {salle.Nom} n'est pas libre le {j.Nom} de {model.Debut.Hour}h{model.Debut.Minute} à {model.Fin.Hour}h{model.Fin.Minute}.");
                    return BadRequest(ModelState);

                }
            }

            //verifion si l'enseigiant es libre
            foreach (var t in repository.TimeTableOfEnseignant(enseignant.Matricule, semestre))
            {
                Periode p = periodeRepository[t.Idperiode];
                Jour j = jourRepository[t.Idjour];

                ModelPeriode model = new ModelPeriode();
                model.SetModelPeriode(p, j);

                if (modelPeriode.OverLap(model))
                {
                    ModelState.AddModelError("enseignant", $"L'enseignant {enseignant.MatriculeNavigation.Nom} n'est pas libre le {j.Nom} de {model.Debut.Hour}h{model.Debut.Minute} à {model.Fin.Hour}h{model.Fin.Minute}.");
                    return BadRequest(ModelState);

                }
            }

            //time = repository.Save(time);

            return Ok(time);
        }
    }
}