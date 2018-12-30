using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories
{
    interface IResultatRepository
    {
        IEnumerable<Resultat> List();
        Resultat FindByMat(string matricule);
        void Save(Resultat resultat);
        void Delete(Resultat resultat);
    }
}
