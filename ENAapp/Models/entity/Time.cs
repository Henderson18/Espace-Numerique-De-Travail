using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Time
    {
        public int Id { get; set; }
        public int Idprogramme { get; set; }
        public int Idsalle { get; set; }
        public int Idperiode { get; set; }
        public int Idjour { get; set; }
        [JsonIgnore]
        public Jour IdjourNavigation { get; set; }
        [JsonIgnore]
        public Periode IdperiodeNavigation { get; set; }
        [JsonIgnore]
        public Programme IdprogrammeNavigation { get; set; }
        [JsonIgnore]
        public Salle IdsalleNavigation { get; set; }
    }
}
