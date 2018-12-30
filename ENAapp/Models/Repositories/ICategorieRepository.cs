using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> List();
        Categorie FindByID(int id);
        void Save(Categorie categorie);
        void Delete(Categorie categorie);
    }
}
