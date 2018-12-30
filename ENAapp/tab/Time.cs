using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Time
    {
        public int Id { get; set; }
        public int? Idprogramme { get; set; }
        public int? Idsalle { get; set; }
        public int? Idperiode { get; set; }
        public int? Idjour { get; set; }

        public Jour IdjourNavigation { get; set; }
        public Periode IdperiodeNavigation { get; set; }
        public Salle IdsalleNavigation { get; set; }
    }
}
