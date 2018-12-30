using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ENAapp.Models.Repositories
{
    public interface ISemestreRepository
    {
        IEnumerable<Semestre> List();
        Semestre FindByMat(int idsemestre);
        void Save(Semestre semestre);
        void Delete(Semestre semestre);
    }
}
