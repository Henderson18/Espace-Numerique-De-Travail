using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class EmpruntRepository : IEmpruntRepository
    {
        private readonly bd_entContext context;

        public EmpruntRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Emprunt _emprunt)
        {
            Emprunt emprunt = context.Emprunt.Find(_emprunt.Id);
            if (emprunt != null)
            {
                context.Emprunt.Remove(emprunt);
                context.SaveChanges();
            }
        }

        public Emprunt FindByID(int id)
        {
            var cust1 = context.Emprunt.Include(e => e.OuvrageNavigation).ThenInclude(o => o.IdCategorieNavigation)
                .Include(e => e.OuvrageNavigation).ThenInclude(e => e.Commentaire).
                First(e => e.Id == id);
            var cust2 = CopyObj(cust1) as Emprunt;
            return cust2;
        }

        public Emprunt Find(int id)
        {
            Emprunt emprunt = context.Emprunt.Include(e => e.OuvrageNavigation).ThenInclude(o => o.IdCategorieNavigation)
                .Include(e => e.OuvrageNavigation).ThenInclude(e => e.Commentaire).
                First(e => e.Id == id);
            return emprunt;
        }

        public IEnumerable<Emprunt> List()
        {
            var cust1 = context.Emprunt.Include(e => e.OuvrageNavigation).ThenInclude(o => o.IdCategorieNavigation)
                .Include(e => e.OuvrageNavigation).ThenInclude(e => e.Commentaire).ToArray();
            var cust2 = CopyObj(cust1) as IEnumerable<Emprunt>;
            return cust2;
        }

        public IEnumerable<Emprunt> ListValides(String mat)
        {
            var cust1 = context.Emprunt.Where(e => (e.Etudiant == mat && (e.Statut == "pret" || e.Statut == "actif"))).ToArray();
            return cust1;
        }

        protected object CopyObj(Object obj)
        {
            return CloneObject(obj);
        }

        private object CloneObject(Object obj)
        {
            if (obj == null)
                return obj;
            string ser = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return (Object)JsonConvert.DeserializeObject(ser, obj.GetType());
        }

        public Emprunt Save(Emprunt _emprunt)
        {
            Emprunt obj = context.Emprunt.Add(_emprunt).Entity;
            context.SaveChanges();
            var cust2 = CopyObj(obj) as Emprunt;
            return cust2;
        }

        public Emprunt Update(Emprunt obj)
        {
            Emprunt emprunt = context.Emprunt.Update(obj).Entity;
            context.SaveChanges();
            var cust2 = CopyObj(emprunt) as Emprunt;
            return cust2;
        }

        public IQueryable EtudiantPret(Compte etudiant)
        {
            var pret = from elt in context.Emprunt
                       where elt.Etudiant == etudiant.Matricule
                       select new {
                          // elt.EtudiantNavigation.Nom,
                           elt.OuvrageNavigation.Titre,
                           elt.OuvrageNavigation.Auteur,
                           elt.OuvrageNavigation.IdCategorieNavigation.Libelle,
                           elt.DateEmprunt,
                           elt.DateRetourTheo,
                           elt.NbAvertissements,
                           elt.Statut



                       };
            return pret;
        }

        public Emprunt Avertir(Emprunt emprunt)
        {
            throw new NotImplementedException();
        }

        public Emprunt Remettre(Emprunt emprunt)
        {
            throw new NotImplementedException();
        }
    }
}
