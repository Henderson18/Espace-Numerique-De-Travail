using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ENT_Background.enumeration;
using ENAapp.Models;

namespace ENAapp.Filters
{
    public class IsAuth : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
                string stringcompte = context.HttpContext.Session.GetString("compte");


                if (stringcompte != null)
                {
                    Compte compte = JsonConvert.DeserializeObject<Compte>(stringcompte);


                    if (compte.Profil != (int)Profil.ADMINISTRATEUR)
                    {
                        context.Result = new RedirectResult("/Home");
                    }
                }

                context.Result = new RedirectResult("/Home");

        }
    }
}
