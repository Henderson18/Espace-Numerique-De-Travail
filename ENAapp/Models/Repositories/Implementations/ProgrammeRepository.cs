using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using Microsoft.EntityFrameworkCore;

namespace ENAapp.Models.Repositories.Implementations
{
    public class ProgrammeRepository : Repository<Programme, int>, IProgrammeRepository
    {
        public ProgrammeRepository(bd_entContext context) : base(context) { }

        public override DbSet<Programme> Collections => context.Programme;

        public override Programme this[int id]
        {
            get
            {
                Programme programme = context.Programme.FirstOrDefault(p => p.Id == id);
                return programme;
            }
        }

        public bool ProgrammeExists(int id)
        {
            return context.Programme.Any(p => p.Id == id);
        }

        public Programme Get(int Idue, int idClasse, int annee)
        {
            Programme programme = context.Programme.Find(Idue, idClasse, annee);
            return programme;
        }
    }
}
