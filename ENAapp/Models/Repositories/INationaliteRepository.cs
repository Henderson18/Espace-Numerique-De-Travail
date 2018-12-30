using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface INationaliteRepository
    {
        IEnumerable<Nationalite> List();
         Nationalite FindByMat(int id);
        void Save(Nationalite nationalite);
        void Delete(Nationalite nationalite);
    }
}
