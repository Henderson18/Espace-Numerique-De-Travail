using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.entity
{
    public class Vue
    {
        public int IdProfile { get; set; }
        public int IdModule { get; set; }
        [JsonIgnore]
        public Module IdModuleNavigation { get; set; }
        [JsonIgnore]
        public Profile IdProfileNavigation { get; set; }
    }
}
