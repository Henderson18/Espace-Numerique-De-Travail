using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Classe
    {
        public Classe()
        {
            Inscrit = new HashSet<Inscrit>();
            Programme = new HashSet<Programme>();
            Resultat = new HashSet<Resultat>();
        }

        public int Idclasse { get; set; }
        public int Idfiliere { get; set; }
        public string Codgrade { get; set; }
        public string Niveau { get; set; }
        public int Idspecialite { get; set; }
        [JsonIgnore]
        public Grade CodgradeNavigation { get; set; }
        [JsonIgnore]
        public Filiere IdfiliereNavigation { get; set; }
        [JsonIgnore]
        public ICollection<Inscrit> Inscrit { get; set; }
        public ICollection<Programme> Programme { get; set; }
        public ICollection<Resultat> Resultat { get; set; }
    }
}
