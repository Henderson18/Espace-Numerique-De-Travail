using ENAapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models
{
    public class LoginModel
    {
        //[Key]
        public string Matricule { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
