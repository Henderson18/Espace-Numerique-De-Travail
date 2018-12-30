using System;
using System.Collections.Generic;

namespace ENAapp.tab
{
    public partial class Vue
    {
        public int IdProfile { get; set; }
        public int IdModule { get; set; }

        public Module IdModuleNavigation { get; set; }
        public Profile IdProfileNavigation { get; set; }
    }
}
