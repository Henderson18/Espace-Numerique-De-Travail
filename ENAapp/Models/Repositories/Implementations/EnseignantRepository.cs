using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class EnseignantRepository : Repository<Compte, string>, IEnseignantRepository
    {
        public EnseignantRepository(bd_entContext context) : base(context) { }

        public override DbSet<Compte> Collections => context.Compte;

        public override IEnumerable<Compte> List()
        {
            return context.Compte.Include(e => e.MatriculeNavigation)
                .Where(e => e.Status == 2)
                .ToArray();
        }

        public override Compte this[string id]
        {
            get
            {
                return context.Compte.FirstOrDefault(c => c.Matricule == id && c.Status == 2);
            }
        }

        public bool EnseignantExists(string matricule)
        {
            return context.Compte.Any(e => e.Matricule == matricule && e.Status == 2);
        }
    }
}
