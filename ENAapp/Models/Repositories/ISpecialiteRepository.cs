using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories
{
   public interface ISpecialiteRepository
    {
        IEnumerable<Specialite> List();
        Specialite FindByMat(int idSpecialite);
        void Save(Specialite specialite);
        void Delete(Specialite specialite);
    }
}
