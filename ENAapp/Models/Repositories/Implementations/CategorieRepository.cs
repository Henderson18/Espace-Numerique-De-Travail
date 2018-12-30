using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly bd_entContext context;

        public CategorieRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Categorie categorie)
        {
            throw new NotImplementedException();
        }

        public Categorie FindByID(int id)
        {
            return context.Categorie.First(c => c.Id == id);
        }

        public IEnumerable<Categorie> List()
        {
            throw new NotImplementedException();
        }

        public void Save(Categorie categorie)
        {
            throw new NotImplementedException();
        }
    }
}
