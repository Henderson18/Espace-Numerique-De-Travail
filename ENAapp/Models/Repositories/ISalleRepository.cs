using ENAapp.Models.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
     public interface ISalleRepository : IRepository<Salle, int>
    {
        bool SalleExists(int id);
    }
}
