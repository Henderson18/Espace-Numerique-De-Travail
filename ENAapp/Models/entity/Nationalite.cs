using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Nationalite
    {
        public Nationalite()
        {
            Etudiant = new HashSet<Etudiant>();
        }

        public string Codnat { get; set; }
        public string Pays { get; set; }
        public string Country { get; set; }

        public ICollection<Etudiant> Etudiant { get; set; }
    }
}
