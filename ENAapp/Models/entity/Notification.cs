using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Objet { get; set; }
        public string Sms { get; set; }
        public string Sender { get; set; }
        public DateTime? Date { get; set; }


        public Etudiant MatriculeNavigation { get; set; }
    }
}
