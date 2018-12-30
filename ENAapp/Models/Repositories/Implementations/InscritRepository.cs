using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class InscritRepository : IInscritRepository
    {
        private readonly bd_entContext context;

        public InscritRepository(bd_entContext cont)
        {
            context = cont;
        }

        public void Delete(Inscrit inscrit)
        {
            context.Inscrit.Remove(inscrit);
            context.SaveChangesAsync();
        }

        public Inscrit FindByMat(string mat)
        {
            return context.Inscrit.Find(mat);
        }

        public IEnumerable<Inscrit> List()
        {
            return context.Inscrit.ToArray();
        }

        public void Save(Inscrit inscrit)
        {
            context.Inscrit.Add(inscrit);
            context.SaveChangesAsync();
        }
        public IQueryable ParcoursEtudiant(string matricule)
        {
            var inscription = from cl in context.Classe
                              from i in context.Inscrit
                              from resultat in context.Resultat
                                  where i.Matricule == matricule && i.Idclasse == cl.Idclasse
                              && i.Matricule==resultat.Matricule &&  resultat.Idclasse==i.Idclasse && i.Annee==resultat.Annee
                              select new
                              {
                                 cl.Codgrade,
                                 cl.Niveau,
                                  resultat
                              };
            return inscription;
        }

        public IQueryable InscriptionEtudiant(Compte compte)
        {
            var user = from i in context.Inscrit
                       where i.Matricule == compte.Matricule
                       select i;
                       
            return user;
        }

        public IQueryable DetailParcours(Moyennes moy)
        {
            var user = from i in context.Inscrit
                       from e in context.Etudiant
                       from classe in context.Classe
                       from resultat in context.Resultat

                       where e.Matricule == moy.Matricule && i.Matricule==e.Matricule && i.Annee==moy.Annee &&
                             classe.Idclasse ==i.Idclasse && resultat.Matricule==i.Matricule && resultat.Annee==moy.Annee
                      
                       select new
                       {
                           e.Nom,
                           classe.Codgrade,
                           classe.Niveau,
                           i,
                           resultat
                       };
            return user;
        }

       
    }
}
