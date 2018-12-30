using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public  class PeriodeRepository : Repository<Periode, int>, IPeriodeRepository
    {
      private  ITimeRepository timeRepository;
      private IClasseRepository classeRepository;

        public PeriodeRepository(bd_entContext context,ITimeRepository timeRepository,IClasseRepository classeRepository): base(context)
        {
         this.timeRepository = timeRepository;
         this.classeRepository = classeRepository;
        }

        public override DbSet<Periode> Collections => context.Periode;

        public bool PeriodeExists(int id)
        {
            return context.Periode.Any(e => e.Id == id);
        }
    }
}
