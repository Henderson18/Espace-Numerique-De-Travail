using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    interface ICourRepository
    {
        IEnumerable<Ue> List();
        Ue FindByMat(int idUe);
        void Save(Ue cour);
        void Delete(Ue cour);
    }
}
