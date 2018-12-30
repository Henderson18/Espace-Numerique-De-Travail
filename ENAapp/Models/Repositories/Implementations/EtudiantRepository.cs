using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly bd_entContext context;

        public  EtudiantRepository (bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Etudiant etudiant)
        {
           Etudiant student= context.Etudiant.Find(etudiant.Matricule);
            if (student != null)
            {
                context.Etudiant.Remove(student);
                context.SaveChangesAsync();
            }
        }


        public IEnumerable<Etudiant> Profile(string mat)
        {
            var etudiant = context.Etudiant.Include(e => e.Inscrit)
                .Include(i => i.Inscrit)
                .Include(e => e.Compte)
                .Where(e => e.Matricule == mat);
            return etudiant.ToList();
        }
            
           /* => context.Etudiant.Where(e => e.Matricule == mat)
            .Include(i => i.Inscrit)
            .Include(c=>c.Compte).ToArray();*/
            
            //.Where(i=>context.Inscrit.Where(i=>))

           

        public IEnumerable<Etudiant> List()
        {
            return context.Etudiant.ToArray();
        }

       
        public void Save(Etudiant etudiant)
        {
            context.Etudiant.Add(etudiant);
            context.SaveChangesAsync();
        }

        public IQueryable ProcessVerbale(string matricule)
        {
            var a = from etudiant in context.Etudiant
                    from inscrit in context.Inscrit
                    from classe in context.Classe
                    
                    where etudiant.Matricule == matricule && inscrit.Matricule == etudiant.Matricule
                    && inscrit.Idclasse == classe.Idclasse
                    from moy in etudiant.Moyennes.Where(e => e.Annee == inscrit.Annee)
                    

               
                    select new 
                    {
                    
                        etudiant.Nom,
                        classe.Codgrade,
                        classe.Niveau,
                        inscrit.Annee,
                        moy.IdueNavigation.Codue,
                        moy

                    };
                  
                       // ee;
                        
                     


            return a;
        }
          //  => From 
      /* => context.Etudiant.Include(l => l.Inscrit)
        .ThenInclude(i => i.IdclasseNavigation)
        .Include(m=>m.Moyennes)
        .ThenInclude(m => m.IdueNavigation)
          .Include(m => m.Moyennes)
        .ThenInclude(m => m.IdsemestreNavigation)
        .Include(m => m.Resultat)
        .ThenInclude(m => m.IdclasseNavigation)
        .First(etu => etu.Matricule == matricule);
        */
        public Etudiant Profile(Compte compte)
        {
            //=>this.FindByMat(compte.Matricule);
            return new Etudiant();
        }

        public IQueryable PvNiveau1(Resultat resultat)
        {
            var a = from etudiant in context.Etudiant
                    from inscrit in context.Inscrit
                    from classe in context.Classe

                    where etudiant.Matricule == resultat.Matricule && inscrit.Matricule ==etudiant.Matricule
                    && resultat.Annee==inscrit.Annee  && inscrit.Idclasse==classe.Idclasse
                    from moy in etudiant.Moyennes.Where(e => e.Annee == resultat.Annee)
                    from result in etudiant.Resultat.Where(r=>r.Annee== resultat.Annee)



                    select new
                    {

                        etudiant.Nom,
                        classe.Codgrade,
                        classe.Niveau,
                        inscrit.Annee,
                        moy.IdueNavigation.Codue,
                        moy,
                        result

                    };

            // ee;




            return a;
        }
        public Etudiant FindByMat(string mat)
        {
            return context.Etudiant.Include(e => e.Inscrit)
                .Include(e => e.Compte).First(e => e.Matricule == mat);
        }

        public Etudiant Search(string mat)
        {
            return context.Etudiant.Find(mat);
        }
    }
}
