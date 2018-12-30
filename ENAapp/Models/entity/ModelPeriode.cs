using System;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.entity
{
    public class ModelPeriode
    {
        public LocalTime Debut { get; set; }
        public LocalTime Fin { get; set; }
        public DayOfWeek Jour { get; set; }

        public bool OverLap(ModelPeriode model)
        {

            return Jour == model.Jour &&
                   Debut.NanosecondOfDay <= model.Debut.NanosecondOfDay &&
                   Fin.NanosecondOfDay >= model.Fin.NanosecondOfDay;
        }

        public bool Overlaps(IEnumerable<ModelPeriode> periodes)
        {
            foreach (var periode in periodes)
            {
                if (this.OverLap(periode)) return true;
            }
            return false;
        }

        public void SetModelPeriode(Periode periode, Jour jour)
        {
            this.Debut = new LocalTime(periode.HeureDebut, periode.MinuteDebut);
            this.Fin = new LocalTime(periode.HeureFin, periode.MinuteFin);
            this.Jour = (System.DayOfWeek)jour.Id;
        }

    }
}
