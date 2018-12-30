using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class SalleRepository: Repository<Salle, int>, ISalleRepository
    {
        public SalleRepository(bd_entContext context) : base(context)
        {

        }
        public override DbSet<Salle> Collections => context.Salle;

        public override Salle this[int id]
        {
            get
            {
                return Collections.Include(s => s.Time).FirstOrDefault(s => s.Id == id);
            }
        }

        public bool SalleExists(int id)
        {
            return context.Salle.Any(e => e.Id == id);
        }
    }
}
