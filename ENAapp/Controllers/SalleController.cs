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
    public class SalleController : Controller
    {
        readonly ISalleRepository repository;

        public SalleController(ISalleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Salle> List() => repository.List();

        [HttpGet("{id}")]
        public Salle Get(int id) => repository[id];
    }
}