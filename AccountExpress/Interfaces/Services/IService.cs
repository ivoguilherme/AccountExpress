using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Post(TEntity obj);

        TEntity Put(TEntity obj);

        void Delete(int id);

        TEntity Get(int id);
        IEnumerable<TEntity> Get();
    }
}
