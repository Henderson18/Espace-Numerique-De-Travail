using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.entity
{
    public partial class Module
    {
        public Module()
        {
            Vue = new HashSet<Vue>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Route { get; set; }
        public string Image { get; set; }
        public ICollection<Vue> Vue { get; set; }
    }
}
