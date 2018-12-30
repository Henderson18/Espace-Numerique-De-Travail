using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public interface IMoyenneRepository
    {
        IEnumerable<Moyennes> List();
        Moyennes FindByMat(string matricule);
        void Save(Moyennes moyenne);
        void Delete(Moyennes moyenne);
        IQueryable MoyenneEtudiantAnnee(string matricule, int semestre, int annee);
        //IQueryable ResultatAnnee(string matricule,)
    }
}
