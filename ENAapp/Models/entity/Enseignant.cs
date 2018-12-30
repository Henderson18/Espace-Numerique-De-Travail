using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Enseignant
    {
        public Enseignant()
        {
            Compte = new HashSet<Compte>();
            Notification = new HashSet<Notification>();
            Programme = new HashSet<Programme>();
        }

        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? Contact { get; set; }

        public ICollection<Compte> Compte { get; set; }
        public ICollection<Notification> Notification { get; set; }
        public ICollection<Programme> Programme { get; set; }
    }
}
