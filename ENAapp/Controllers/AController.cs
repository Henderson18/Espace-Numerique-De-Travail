using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.entity;
using ENAapp.Models.Repositories;
using ENAapp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENAapp.Controllers
{
    [Route("api/[controller]")]
    public class AController : Controller
    {
        private IVueRepository vueRepository;

        private ICompteRepository compteRepository;

        public AController(IVueRepository vueRepository,ICompteRepository compteRepository)
        {
            this.vueRepository = vueRepository;
            this.compteRepository = compteRepository;
        }

        [HttpGet]
        public IEnumerable<Compte> GetAllAccount()
        {
            return this.compteRepository.ListCompte();
        }
    }
}