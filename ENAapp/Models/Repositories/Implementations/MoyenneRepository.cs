using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class MoyenneRepository:IMoyenneRepository
    {
        private readonly bd_entContext context;
        public MoyenneRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Moyennes moyenne)
        {
            context.Moyennes.Remove(moyenne);
            context.SaveChangesAsync();
        }

        public Moyennes FindByMat(string matricule)
        {
            return context.Moyennes.Find(matricule);
        }

        public IEnumerable<Moyennes> List()
        {
            List<Moyennes> moyennes = context.Moyennes.ToList();

            return moyennes;
        }

        public void Save(Moyennes moyenne)
        {
            context.Moyennes.Add(moyenne);
            context.SaveChangesAsync();
        }

        public IQueryable MoyenneEtudiantAnnee(string matricule, int semestre, int annee)
        {
            var moyenne = from ue in context.Ue from elt in context.Moyennes
                          where elt.Matricule == matricule && elt.Idsemestre == semestre && elt.Annee == annee
                          && ue.IdUe == elt.Idue
                          select new
                          {
                             ue.Intitule,
                             ue.Codue,
                             elt
                             
                          };
            return moyenne;
        }
    }
}
