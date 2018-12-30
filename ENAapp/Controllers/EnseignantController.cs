using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class EnseignantController : Controller
    {
        readonly IEnseignantRepository repository;
        public EnseignantController(IEnseignantRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Compte> List() => repository.List();
    }
}