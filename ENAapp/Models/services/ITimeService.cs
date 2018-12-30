using ENAapp.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.services
{
    public interface ITimeService
    {
        IEnumerable<ModelPeriode> ModelPeriodes(IEnumerable<Time> times);
    }
}
