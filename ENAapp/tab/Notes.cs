using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Notes
    {
        public uint Idue { get; set; }
        public string Matricule { get; set; }
        public string Codeevaluation { get; set; }
        public int Idsemestre { get; set; }
        public int Annee { get; set; }
        public string Anonymat { get; set; }
        public decimal? Note { get; set; }

        public Semestre IdsemestreNavigation { get; set; }
        public Ue IdueNavigation { get; set; }
        public Etudiant MatriculeNavigation { get; set; }
    }
}
