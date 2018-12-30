using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface IGradeRepository
    {

        IEnumerable<Grade> List();
        Grade FindByMat(string mat);
        void Save(Grade grade);
        void Delete(Grade grade);
    }
}
