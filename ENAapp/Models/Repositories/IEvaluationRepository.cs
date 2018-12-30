using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    interface IEvaluationRepository
    {
        IEnumerable<Typeevaluation> List();
        Typeevaluation FindByMat(string codeEvaluation);
        void Save(Typeevaluation typeevaluation);
        void Delete(Typeevaluation typeevaluation);
    }
}
