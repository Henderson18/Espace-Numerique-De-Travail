using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Moyennes
    {
        public string Matricule { get; set; }
        public uint Idue { get; set; }
        public int Idsemestre { get; set; }
        public int Annee { get; set; }
        public decimal? Moyenne { get; set; }
        public string Codmention { get; set; }
        public uint Credit { get; set; }
        public decimal QdP { get; set; }
        public string Decision { get; set; }

        public Semestre IdsemestreNavigation { get; set; }
        public Ue IdueNavigation { get; set; }
        public Etudiant MatriculeNavigation { get; set; }
    }
}
