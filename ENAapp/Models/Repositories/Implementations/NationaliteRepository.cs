using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class NationaliteRepository: INationaliteRepository
    {
        private readonly bd_entContext context;
        public NationaliteRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Nationalite nationalite)
        {
            context.Nationalite.Remove(nationalite);
            context.SaveChangesAsync();
        }

        public Nationalite FindByMat(int id)
        {
           return context.Nationalite.Find(id);
        }

        public IEnumerable<Nationalite> List()
        {
            return context.Nationalite.ToArray();
        }

        public void Save(Nationalite nationalite)
        {
            context.Nationalite.Add(nationalite);
            context.SaveChangesAsync();
        }
    }
}
