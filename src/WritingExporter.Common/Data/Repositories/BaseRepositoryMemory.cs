using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Data.Repositories
{
    public class BaseMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : class
    {
        Dictionary<TKey, TEntity> _dict;
        object _lock = new object();

        public BaseMemoryRepository()
        {
            _dict = new Dictionary<TKey, TEntity>();
        }

        public void Add(TEntity entity)
        {
            lock (_lock)
            {
                _dict.Add(GetKey(entity), entity);
            }
        }

        public void Delete(TEntity entity)
        {
            lock (_lock)
            {
                _dict.Remove(GetKey(entity));
            }
        }

        public void DeleteById(TKey key)
        {
            lock (_lock)
            {
                _dict.Remove(key);
            }
        }

        public TEntity GetByID(TKey key)
        {
            lock (_lock)
            {
                return _dict[key];
            }
        }

        public void Save(TEntity entity)
        {
            lock (_lock)
            {
                _dict[GetKey(entity)] = entity;
            }
        }

        IEnumerable<TEntity> IRepository<TEntity, TKey>.GetAll()
        {
            lock (_lock)
            {
                return _dict.DeepClone().Values;
            }
        }

        private TKey GetKey(TEntity entity)
        {
            lock (_lock)
            {
                throw new NotImplementedException();
            }
        }
    }
}
