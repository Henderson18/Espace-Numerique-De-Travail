using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Models.Repositories.Implementations
{
    public interface IRepository<T, ID>
    {
        IEnumerable<T> List();
        T this[ID id] { get; }
        T Save(T obj);
        T Update(T obj);
        void Delete(T obj);

    }
}
