using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface IFiliereRepository
    {
        IEnumerable<Filiere> List();
        Filiere FindByMat(string mat);
        void Save(Filiere classe);
        void Delete(Filiere etudiant);
      
    }
}
