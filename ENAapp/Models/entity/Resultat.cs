using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Resultat
    {
        public int Idclasse { get; set; }
        public string Matricule { get; set; }
        public int Annee { get; set; }
        public int Semestre { get; set; }
        public string Creditcap { get; set; }
        public string Creditchoisis { get; set; }
        public string Pourcentcap { get; set; }
        public string Mgp { get; set; }
        public string Decision { get; set; }
        public int? Newidclasse { get; set; }
        public string Grade { get; set; }
        public string Newgrade { get; set; }

        public Grade GradeNavigation { get; set; }
        public Classe IdclasseNavigation { get; set; }
        public Etudiant MatriculeNavigation { get; set; }
        public Semestre SemestreNavigation { get; set; }
    }
}
