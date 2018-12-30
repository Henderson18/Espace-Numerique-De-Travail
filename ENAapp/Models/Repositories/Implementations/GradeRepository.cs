using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class GradeRepository : IGradeRepository
    {
        private readonly bd_entContext context;
        public GradeRepository(bd_entContext context)
        {
            this.context = context;
        }
        public void Delete(Grade grade)
        {
            context.Grade.Remove(grade);
            context.SaveChangesAsync();
        }

        public Grade FindByMat(string mat)
        {
            return context.Grade.Find(mat);
        }

        public IEnumerable<Grade> List()
        {
            return context.Grade.ToArray();
        }

        public void Save(Grade grade)
        {
            context.Grade.Add(grade);
            context.SaveChangesAsync();
        }
    }
}
