using ENAapp.Models.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
     public interface IEnseignantRepository: IRepository<Compte, string>
    {
        bool EnseignantExists(string matricule);
    }
}
