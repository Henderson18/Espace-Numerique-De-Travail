using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Ouvrage
    {
        public Ouvrage()
        {
            Commentaire = new HashSet<Commentaire>();
            Emprunt = new HashSet<Emprunt>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Description { get; set; }
        public int AnneePublication { get; set; }
        public string Discipline { get; set; }
        public int IdCategorie { get; set; }
        public string ImgCouverture { get; set; }
        public int? Quantite { get; set; }
        [JsonIgnore]
        public Categorie IdCategorieNavigation { get; set; }
        public ICollection<Commentaire> Commentaire { get; set; }
        public ICollection<Emprunt> Emprunt { get; set; }
    }
}
