using ENAapp.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
     public interface IVueRepository
    {
        IQueryable getVue(int? profile);
    }
}
