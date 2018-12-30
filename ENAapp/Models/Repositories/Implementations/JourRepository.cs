using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class JourRepository : Repository<Jour, int>, IJourRepository
    {
        public JourRepository(bd_entContext context) : base(context)
        {

        }
        public override DbSet<Jour> Collections => context.Jour;

        public bool JourExists(int id)
        {
            return context.Jour.Any(e => e.Id == id);
        }

    }
}
