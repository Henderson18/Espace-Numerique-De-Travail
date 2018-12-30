using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class CourRepository:ICourRepository
    {
        private readonly bd_entContext context;
        public CourRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Ue cour)
        {
            context.Ue.Remove(cour);
            context.SaveChangesAsync();
        }

        public Ue FindByMat(int idUe)
        {
            return context.Ue.Find(idUe);
        }

        public IEnumerable<Ue> List()
        {
            return context.Ue.ToArray();
        }

        public void Save(Ue cour)
        {
            context.Ue.Add(cour);
            context.SaveChangesAsync();
        }
    }
}
