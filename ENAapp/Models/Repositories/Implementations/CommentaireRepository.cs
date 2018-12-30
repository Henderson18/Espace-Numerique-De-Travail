using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public class CommentaireRepository :ICommentaireRepository
    {
        private readonly bd_entContext context;

        public CommentaireRepository( bd_entContext context)
        {
            this.context = context;
        }

        public void Delete(Commentaire commentaire)
        {
            throw new NotImplementedException();
        }

        public Commentaire FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commentaire> List()
        {
            throw new NotImplementedException();
        }

        public void Save(Commentaire comment)
        {
            throw new NotImplementedException();
        }
    }
}
