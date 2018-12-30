using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;
using ENAapp.Models.Repositories.Implementations;

namespace ENAapp.Models.Repositories
{
   public  interface IProgrammeRepository : IRepository<Programme, int>
    {
        bool ProgrammeExists(int id);
        Programme Get(int Idue, int idClasse, int annee);
    }
}
