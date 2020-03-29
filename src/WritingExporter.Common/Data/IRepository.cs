using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Data
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : class
    {
        TEntity GetByID(TKey key);
        
        ICollection<TEntity> GetAll();

        void Add(TEntity entity);

        void Save(TEntity entity);

        void Delete(TEntity entity);
    }
}
