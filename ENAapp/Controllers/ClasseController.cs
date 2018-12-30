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
    public class ClasseController : ControllerBase
    {
        private readonly IClasseRepository repository;

        public ClasseController(IClasseRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public Classe Get(int id) => repository[id];

        [HttpGet]
        public IEnumerable<Classe> List() => repository.List();
    }
}