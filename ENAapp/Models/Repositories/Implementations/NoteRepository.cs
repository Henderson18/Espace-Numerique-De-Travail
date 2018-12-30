using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using Microsoft.EntityFrameworkCore;

namespace ENAapp.Models.Repositories.Implementations
{
    public class NoteRepository:INoteRepository
    {
        private readonly bd_entContext context;

        public NoteRepository(bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Notes notes)
        {
            context.Notes.Remove(notes);
            context.SaveChangesAsync();
        }

        public Notes FindByMat(string mat)
        {
            return context.Notes.Find(mat);
        }

        public IEnumerable<Notes> List()
        {
            return context.Notes.ToArray();
        }

        public void Save(Notes notes)
        {
            context.Notes.Add(notes);
            context.SaveChangesAsync();
        }

        public IQueryable NotesEtudiant(string matricule, int semestre)
        {

            var a =  from note in context.Notes
                    where note.Matricule == matricule && note.Annee == 2018 && note.Idsemestre == semestre
                    select new  
                    {
                       note.IdueNavigation.Codue,
                       note.IdueNavigation.Intitule,
                       note.Codeevaluation,
                       note.Matricule,
                       note.Note,
                       note.Idsemestre,
                       note.Annee,
                       note.IdueNavigation.IdfiliereNavigation.Name
                    };


            return a;
        }
            
        




    }
}
