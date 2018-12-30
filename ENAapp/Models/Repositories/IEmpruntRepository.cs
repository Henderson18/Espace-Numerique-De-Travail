using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface IEmpruntRepository
    {
        IEnumerable<Emprunt> List();
        Emprunt FindByID(int id);
       Emprunt Save(Emprunt emprunt);
        Emprunt Update(Emprunt emprunt);
        void Delete(Emprunt emprunt);
        IEnumerable<Emprunt> ListValides(String mat);
        Emprunt Find(int id);
        IQueryable EtudiantPret(Compte etudiant);
        Emprunt Avertir(Emprunt emprunt);
        Emprunt Remettre(Emprunt emprunt);
    }
}
