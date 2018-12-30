using System;
using System.Collections.Generic;

namespace ENAapp.tab
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

        public ICollection<Time> Time { get; set; }
    }
}
