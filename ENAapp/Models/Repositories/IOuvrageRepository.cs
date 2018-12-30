using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public  interface IOuvrageRepository
    {
        IEnumerable<Ouvrage> List();
        Ouvrage FindByID(int id);
        Ouvrage Save(Ouvrage ouvrage);
        void Delete(Ouvrage ouvrage);
        Ouvrage Update(Ouvrage obj);

    }
}
