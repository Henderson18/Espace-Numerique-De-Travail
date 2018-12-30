using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class ResultatRepository: IResultatRepository
    {
        private readonly bd_entContext context;
        public ResultatRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Resultat resultat)
        {
            context.Resultat.Remove(resultat);
            context.SaveChangesAsync();
        }

        public Resultat FindByMat(string matricule)
        {
            return context.Resultat.Find(matricule);
        }

        public IEnumerable<Resultat> List()
        {
            return context.Resultat.ToArray();
        }

        public void Save(Resultat resultat)
        {
            context.Resultat.Add(resultat);
            context.SaveChangesAsync();
        }
    }
}
