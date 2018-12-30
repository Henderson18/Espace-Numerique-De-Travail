using ENAapp.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.services
{
    public class TimeService:ITimeService
    {
        public IEnumerable<ModelPeriode> ModelPeriodes(IEnumerable<Time> times)
        {
            IEnumerable<ModelPeriode> modelPeriodes = new List<ModelPeriode>();

            foreach (var time in times)
            {
                ModelPeriode periode = new ModelPeriode();
                periode.SetModelPeriode(time.IdperiodeNavigation, time.IdjourNavigation);

                modelPeriodes.Append(periode);
            }

            return modelPeriodes;
        }
    }
}
