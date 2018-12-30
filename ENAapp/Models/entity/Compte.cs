using ENAapp.Models.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Compte
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Passhash { get; set; }
        public string Email { get; set; }
        public string Imgsrc { get; set; }
        public string ConfirmationToken { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ConfirmatAt { get; set; }
        public DateTime? ResetAt { get; set; }
        public int? Status { get; set; }
        public int? Profil { get; set; }
        [JsonIgnore]
        public Etudiant MatriculeNavigation { get; set; }

        public Profile ProfilNavigation { get; set; }
    }
}
