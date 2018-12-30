using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class EmpruntController : Controller
    {
        private IOuvrageRepository ouvrageRepository;
        private IEtudiantRepository etudiantRepository;
        private IEmpruntRepository empruntRepository;
        Ouvrage ouv;
        IEnumerable<Emprunt> empValList;

        public EmpruntController(IOuvrageRepository _ouvrageRepository, IEtudiantRepository _etudiantRepository,
            IEmpruntRepository _empruntRepository)
        {
            this.ouvrageRepository = _ouvrageRepository;
            this.etudiantRepository = _etudiantRepository;
            this.empruntRepository = _empruntRepository;

        }

        [HttpGet]
        public IEnumerable<Emprunt> List() => empruntRepository.List();

        [HttpGet("details/{id}")]
        public Emprunt Get(int id)
        {
            return empruntRepository.FindByID(id);
        }

        [HttpPost]
        public Emprunt Add ([FromBody] Emprunt obj)
        {
            ouv = obj.OuvrageNavigation = ouvrageRepository.FindByID(obj.Ouvrage);
            obj.EtudiantNavigation = etudiantRepository.FindByMat(obj.Etudiant);
            empValList = empruntRepository.ListValides(obj.Etudiant);
            if (ouv.Quantite == 0 || empValList.Count() >= 3)
                return null;
            else
            {
                foreach (Emprunt emp in empValList)
                {
                    if (emp.Ouvrage.Equals(ouv.Id))
                        return null;
                }
            }

           ouv.Quantite--;
            ouvrageRepository.Update(ouv);
            obj.DateEmprunt = DateTime.Now;
            obj.DateRetourTheo = DateTime.Now.AddDays(7);
            obj.DateRetourEff = DateTime.Now.AddDays(8);
            obj.NbAvertissements = 0;
            obj.Statut = "pret";
            return empruntRepository.Save(obj);
        }

       /* [HttpPut]
        public Emprunt Update([FromBody] Emprunt obj)
        {
            return empruntRepository.Update(obj);
        }*/

        [HttpPatch("{id}")]
        public Emprunt UpdateProperties(int id, [FromBody] JsonPatchDocument<Emprunt> patch)
        {
            Emprunt emprunt = empruntRepository.Find(id);
            patch.ApplyTo(emprunt);
            if (emprunt.Statut.Equals("termine"))
            {
                ouv = ouvrageRepository.FindByID(emprunt.Ouvrage);
                ouv.Quantite++;
                ouvrageRepository.Update(ouv);
                emprunt.DateRetourEff = DateTime.Now;
                Console.WriteLine("termine");
            }
            return empruntRepository.Update(emprunt);
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            empruntRepository.Delete(empruntRepository.FindByID(id));
            return Ok();
        }
        [HttpPut]
        public IQueryable mesEmprunt([FromBody]Compte etudiant)
        {
            return empruntRepository.EtudiantPret(etudiant);


        }

    }
}