using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class OuvrageRepository : IOuvrageRepository
    {
        private bd_entContext context;

        public OuvrageRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Ouvrage _ouvrage)
        {
            Ouvrage ouvrage = context.Ouvrage.Find(_ouvrage.Id);
            if (ouvrage != null)
            {
                context.Ouvrage.Remove(ouvrage);
                context.SaveChanges();
            }
        }

        public Ouvrage FindByID(int id)
        {
            return context.Ouvrage.Include(o => o.IdCategorieNavigation)
                .Include(c => c.Commentaire).First(a => a.Id == id);
        }

        public IEnumerable<Ouvrage> List()
        {
            return context.Ouvrage.Include(o => o.IdCategorieNavigation)
                .Include(c => c.Commentaire).ToArray();
        }

        public Ouvrage Save(Ouvrage ouvrage)
        {
            Ouvrage obj = context.Ouvrage.Add(ouvrage).Entity;
            context.SaveChanges();
            return obj;
        }

        public Ouvrage Update(Ouvrage obj)
        {
            Ouvrage ouvrage = context.Ouvrage.Update(obj).Entity;
            context.SaveChanges();
            return ouvrage;
        }
    }
}
