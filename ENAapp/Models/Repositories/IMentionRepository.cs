using System;
using System.Collections.Generic;
using System.Linq;
using ENAapp.Models;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories
{
   public interface IMentionRepository
    {
        IEnumerable<Mention> List();
        Mention FindByMat(int id);
        void Save(Mention mention);
        void Delete(Mention mention);
    }
}
