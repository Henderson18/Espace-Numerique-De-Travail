using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public  interface INoteRepository
    {
        IEnumerable<Notes> List();
        Notes FindByMat(string mat);
        void Save(Notes notes);
        void Delete(Notes notes);
        IQueryable NotesEtudiant(string matricule, int semestre);
    }
}
