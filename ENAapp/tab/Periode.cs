using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Periode
    {
        public Periode()
        {
            Time = new HashSet<Time>();
        }

        public int Id { get; set; }
        public int HeureDebut { get; set; }
        public int MinuteDebut { get; set; }
        public int HeureFin { get; set; }
        public int MinuteFin { get; set; }

        public ICollection<Time> Time { get; set; }
    }
}
