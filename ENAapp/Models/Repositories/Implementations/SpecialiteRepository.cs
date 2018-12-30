using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class SpecialiteRepository :ISpecialiteRepository
    {
        private readonly bd_entContext context;

        public SpecialiteRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Specialite specialite)
        {
            context.Specialite.Remove(specialite);
            context.SaveChangesAsync();
        }

        public Specialite FindByMat(int idSpecialite)
        {
            return context.Specialite.Find(idSpecialite);
        }

        public IEnumerable<Specialite> List()
        {
            return context.Specialite.ToArray();
        }

        public void Save(Specialite specialite)
        {
            context.Specialite.Add(specialite);
            context.SaveChangesAsync();
        }
    }
}
