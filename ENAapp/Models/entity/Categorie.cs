using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Ouvrage = new HashSet<Ouvrage>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public ICollection<Ouvrage> Ouvrage { get; set; }
    }
}
