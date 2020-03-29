using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Data
{
    public class BaseMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : class
    {
        Dictionary<TKey, TEntity> _dict;
        object _lock;

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
