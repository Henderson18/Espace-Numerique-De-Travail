using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Commentaire
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public int Ouvrage { get; set; }
        public DateTime Date { get; set; }
        public string Contenu { get; set; }

        public Etudiant MatriculeNavigation { get; set; }
        public Ouvrage OuvrageNavigation { get; set; }
    }
}
