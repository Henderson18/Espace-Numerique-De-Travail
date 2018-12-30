using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class SemestreRepository:ISemestreRepository
    {
        private readonly bd_entContext context;
        public SemestreRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Semestre semestre)
        {
            context.Semestre.Remove(semestre);
            context.SaveChangesAsync();
        }

        public Semestre FindByMat(int idsemestre)
        {
            return context.Semestre.Find(idsemestre);
        }

        public IEnumerable<Semestre> List()
        {
            return context.Semestre.ToArray();
        }

        public void Save(Semestre semestre)
        {
            context.Semestre.Add(semestre);
            context.SaveChangesAsync();
        }
    }
}
