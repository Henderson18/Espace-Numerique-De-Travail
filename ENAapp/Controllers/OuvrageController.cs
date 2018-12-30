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
    public class OuvrageController : Controller
    {
        private IOuvrageRepository ouvrageRepository;
        private ICategorieRepository categoryRepository;

        public OuvrageController(IOuvrageRepository _ouvrageRepository, ICategorieRepository _categoryRepository)
        {
            this.ouvrageRepository = _ouvrageRepository;
            this.categoryRepository = _categoryRepository;
        }

        [HttpGet]
        public IEnumerable<Ouvrage> List() => ouvrageRepository.List();

        [HttpGet("{id}")]
        public Ouvrage Get(int id)
        {
            return ouvrageRepository.FindByID(id);
        }

        [HttpPost]
        public Ouvrage Add([FromBody] Ouvrage obj)
        {
            obj.IdCategorieNavigation = categoryRepository.FindByID(obj.IdCategorie);
            return ouvrageRepository.Save(obj);
        }

        [HttpPut]
        public Ouvrage Update([FromBody] Ouvrage obj)
        {
            Ouvrage ouvrage = ouvrageRepository.FindByID(obj.Id);
            ouvrage.Titre = obj.Titre;
            ouvrage.Auteur = obj.Auteur;
            ouvrage.Description = obj.Description;
            ouvrage.AnneePublication = obj.AnneePublication;
            ouvrage.Discipline = obj.Discipline;
            ouvrage.IdCategorie = obj.IdCategorie;
            ouvrage.ImgCouverture = obj.ImgCouverture;
            ouvrage.Quantite = obj.Quantite;
            ouvrage.IdCategorieNavigation = categoryRepository.FindByID(obj.IdCategorie);
            return ouvrageRepository.Update(ouvrage);
        }

        [HttpPatch("{id}")]
        public Ouvrage UpdateProperties(int id, [FromBody] JsonPatchDocument<Ouvrage> patch)
        {
            Ouvrage ouvrage = ouvrageRepository.FindByID(id);
            patch.ApplyTo(ouvrage);
            ouvrageRepository.Update(ouvrage);
            return ouvrage;
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            ouvrageRepository.Delete(ouvrageRepository.FindByID(id));
            return Ok();
        }
    }
}