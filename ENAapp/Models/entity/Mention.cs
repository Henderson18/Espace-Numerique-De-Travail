using System;
using System.Collections.Generic;

namespace ENAapp.Models
{
    public partial class Mention
    {
        public string Codmention { get; set; }
        public decimal Valeurmin { get; set; }
        public decimal Valeurmax { get; set; }
        public decimal? Qualitepoints { get; set; }
        public int Etat { get; set; }
    }
}
