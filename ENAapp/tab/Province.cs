using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Province
    {
        public Province()
        {
            Etudiant = new HashSet<Etudiant>();
        }

        public string Codprovince { get; set; }
        public string Nomprovince { get; set; }
        public string Provname { get; set; }

        public ICollection<Etudiant> Etudiant { get; set; }
    }
}
