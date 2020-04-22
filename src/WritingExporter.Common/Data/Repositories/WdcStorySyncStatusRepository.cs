using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;

namespace WritingExporter.Common.Data.Repositories
{
    public class WdcStorySyncStatusRepository : IRepository<WdcStorySyncStatus, string>
    {
        object _lock;
        Dictionary<string, WdcStorySyncStatus> _db;

        public WdcStorySyncStatusRepository()
        {
            _db = new Dictionary<string, WdcStorySyncStatus>();
        }

        public void Add(WdcStorySyncStatus entity)
        {
            _db.Add(entity.SysId, entity);
        }

        public void Delete(WdcStorySyncStatus entity)
        {
            _db.Remove(entity.SysId);
        }

        public IEnumerable<WdcStorySyncStatus> GetAll()
        {
            return _db.Values.Select((ent) => ent).ToArray();
        }

        public WdcStorySyncStatus GetByID(string key)
        {
            return _db[key].DeepClone();
        }

        public void Save(WdcStorySyncStatus entity)
        {
            _db[entity.SysId] = entity;
        }
    }
}
