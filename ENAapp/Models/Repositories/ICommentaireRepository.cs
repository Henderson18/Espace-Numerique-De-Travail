using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
    public interface ICommentaireRepository
    {
        IEnumerable<Commentaire> List();
        Commentaire FindByID(int id);
        void Save(Commentaire comment);
        void Delete(Commentaire commentaire);
    }
}
