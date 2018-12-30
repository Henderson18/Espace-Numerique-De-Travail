using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Specialite
    {
        public int Idspecialite { get; set; }
        public int Idfiliere { get; set; }
        public string Codspecialite { get; set; }
        public string Intitule { get; set; }
        public string Entitle { get; set; }

        public Filiere IdfiliereNavigation { get; set; }
    }
}
