using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models.entity;

namespace ENAapp.Models.Repositories.Implementations
{
    public class VueRepository :IVueRepository
    {
        private readonly bd_entContext context;
        public VueRepository( bd_entContext context)
        {
            this.context = context;
        }

        public IQueryable getVue(int? profile)
        {
            var vue = from v in context.Vue
                      where v.IdProfile == profile
                      select new
                      {
                         // v,
                          v.IdModuleNavigation
                      };
            return vue;
        }
    }
}
