using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Emprunt
    {
        public int Id { get; set; }
        public string Etudiant { get; set; }
        public int Ouvrage { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetourTheo { get; set; }
        public DateTime? DateRetourEff { get; set; }
        public int? NbAvertissements { get; set; }
        public string Statut { get; set; }

        public Etudiant EtudiantNavigation { get; set; }
        public Ouvrage OuvrageNavigation { get; set; }
    }
}
