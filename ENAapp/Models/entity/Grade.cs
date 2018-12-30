using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Classe = new HashSet<Classe>();
            Resultat = new HashSet<Resultat>();
        }

        public string Codgrade { get; set; }
        public string Intitule { get; set; }

        public ICollection<Classe> Classe { get; set; }
        public ICollection<Resultat> Resultat { get; set; }
    }
}
