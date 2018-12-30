using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Ue
    {
        public Ue()
        {
            Moyennes = new HashSet<Moyennes>();
            Notes = new HashSet<Notes>();
            Programme = new HashSet<Programme>();
        }

        public uint IdUe { get; set; }
        public int? Idfiliere { get; set; }
        public string Codue { get; set; }
        public string Intitule { get; set; }
        public string Title { get; set; }
        public int Annee { get; set; }

        public Filiere IdfiliereNavigation { get; set; }
        public ICollection<Moyennes> Moyennes { get; set; }
        public ICollection<Notes> Notes { get; set; }
        public ICollection<Programme> Programme { get; set; }
    }
}
