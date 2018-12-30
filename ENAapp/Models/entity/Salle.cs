using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Salle
    {
        public Salle()
        {
            Time = new HashSet<Time>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public uint Capacite { get; set; }
        [JsonIgnore]
        public ICollection<Time> Time { get; set; }
    }
}
