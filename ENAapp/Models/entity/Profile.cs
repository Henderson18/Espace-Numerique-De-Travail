using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.entity
{
    public partial  class Profile
    {
        public Profile()
        {
            Compte = new HashSet<Compte>();
            Vue = new HashSet<Vue>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Compte> Compte { get; set; }
        public ICollection<Vue> Vue { get; set; }
    }
}
