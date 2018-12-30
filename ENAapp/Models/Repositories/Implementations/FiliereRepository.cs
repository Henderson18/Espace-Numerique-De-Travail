using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories
{
    public class FiliereRepository : IFiliereRepository
    {
        private readonly bd_entContext context;

        public FiliereRepository(bd_entContext context)
        {
            this.context = context;
        }
        public void Delete(Filiere filiere)
        {
            context.Filiere.Remove(filiere);
            context.SaveChangesAsync();
        }

        public Filiere FindByMat(string mat)
        {
            return context.Filiere.Find(mat);
        }

        public IEnumerable<Filiere> List()
        {
            return context.Filiere.ToArray();
        }

        public void Save(Filiere filiere)
        {
            context.Filiere.Add(filiere);
        }
    }
}
