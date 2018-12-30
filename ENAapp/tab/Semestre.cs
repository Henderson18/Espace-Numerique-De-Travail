using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Semestre
    {
        public Semestre()
        {
            Moyennes = new HashSet<Moyennes>();
            Notes = new HashSet<Notes>();
            Programme = new HashSet<Programme>();
            Resultat = new HashSet<Resultat>();
        }

        public int Idsemestre { get; set; }
        public string Description { get; set; }

        public ICollection<Moyennes> Moyennes { get; set; }
        public ICollection<Notes> Notes { get; set; }
        public ICollection<Programme> Programme { get; set; }
        public ICollection<Resultat> Resultat { get; set; }
    }
}
