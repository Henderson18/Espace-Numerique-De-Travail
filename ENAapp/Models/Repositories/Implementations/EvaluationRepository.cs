using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class EvaluationRepository:IEvaluationRepository
    {
        private readonly bd_entContext context;
        public EvaluationRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Typeevaluation typeevaluation)
        {
            context.Typeevaluation.Remove(typeevaluation);
            context.SaveChangesAsync();
        }

        public Typeevaluation FindByMat(string codeEvaluation)
        {
            return context.Typeevaluation.Find(codeEvaluation);
        }

        public IEnumerable<Typeevaluation> List()
        {
            return context.Typeevaluation.ToArray();
        }

        public void Save(Typeevaluation typeevaluation)
        {
            context.Typeevaluation.Add(typeevaluation);
            context.SaveChangesAsync();
        }
    }
}
