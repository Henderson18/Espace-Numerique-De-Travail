using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;

namespace ENAapp.Models.Repositories.Implementations
{
    public class MentionRepository : IMentionRepository
    {
        private readonly bd_entContext context;
        public MentionRepository(bd_entContext context)
        {
            this.context = context;    
        }
        public void Delete(Mention mention)
        {
            context.Mention.Remove(mention);
            context.SaveChangesAsync();
        }

        public Mention FindByMat(int id)
        {
            return context.Mention.Find(id);
        }

        public IEnumerable<Mention> List()
        {
            return context.Mention.ToArray();
        }

        public void Save(Mention mention)
        {
            context.Mention.Add(mention);
        }
    }
}
