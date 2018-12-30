using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Inscrit
    {
        public int Idclasse { get; set; }
        public string Matricule { get; set; }
        public int Annee { get; set; }

        public Classe IdclasseNavigation { get; set; }
        [JsonIgnore]
        public Etudiant MatriculeNavigation { get; set; }
    }
}
