using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface IInscritRepository
    {
        IEnumerable<Inscrit> List();
        Inscrit FindByMat(string mat);
        void Save(Inscrit inscrit);
        void Delete(Inscrit inscrit);
        IQueryable ParcoursEtudiant(string etudiant);
        IQueryable InscriptionEtudiant(Compte compte);
        IQueryable DetailParcours(Moyennes moy);
    }
}
