using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface IEtudiantRepository
    {
        IEnumerable<Etudiant> List();
        IEnumerable<Etudiant> Profile(string mat);
        void Save(Etudiant etudiant);
        void Delete(Etudiant etudiant);
        Etudiant FindByMat(string mat);
        IQueryable ProcessVerbale(string matricule);
        IQueryable PvNiveau1(Resultat resultat);
        Etudiant Search(string mat);
      
       

    }
}
