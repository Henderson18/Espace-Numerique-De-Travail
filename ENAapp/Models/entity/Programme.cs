using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Programme
    {
        public int Id { get; set; }
        public int Idclasse { get; set; }
        public uint Idue { get; set; }
        public int Annee { get; set; }
        public int Semestre { get; set; }
        public int? Categorie { get; set; }
        public int? Credit { get; set; }
        public string Enseignant { get; set; }

        public Etudiant EnseignantNavigation { get; set; }
        public Classe IdclasseNavigation { get; set; }
        public Ue IdueNavigation { get; set; }
        public Semestre SemestreNavigation { get; set; }
    }
}
