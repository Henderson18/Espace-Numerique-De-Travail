using ENAapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class ClasseRepository :  Repository<Classe, int>, IClasseRepository {

        public ClasseRepository(bd_entContext context) : base(context)
        {

        }
        public override DbSet<Classe> Collections => context.Classe;

        public override Classe this[int id]
        {
            get
            {
                Classe obj = context.Classe.Include(f => f.IdfiliereNavigation).First(c => c.Idclasse == id);
                return obj;
            }
        }

        public override IEnumerable<Classe> List()
        {
            return context.Classe
                    .Include(f => f.IdfiliereNavigation)
                    .Where(c => c.Idspecialite == 4)
                    .ToArray();
        }

        public bool ClasseExists(int id)
        {
            return context.Classe.Any(e => e.Idclasse == id);
        }
    }
}

