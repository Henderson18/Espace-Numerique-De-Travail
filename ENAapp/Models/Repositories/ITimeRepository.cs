using ENAapp.Models.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public  interface ITimeRepository: IRepository<Time, int>
    {
        IEnumerable<Time> TimeTableOfClasse(int idClasse, int semestre);
        IEnumerable<Time> TimeTableOfSalle(int idSalle, int semestre);
        IEnumerable<Time> TimeTableOfEnseignant(string matriculeEnseignant, int semestre);

        IEnumerable<Periode> PeriodesOfClasse(int idClasse);
        IEnumerable<Periode> PeriodesOfSalle(int idSalle);
        IEnumerable<Periode> PeriodesOfEnseignant(string idEnseignant);
    }
}
