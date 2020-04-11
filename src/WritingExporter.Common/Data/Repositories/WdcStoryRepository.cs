using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;

namespace WritingExporter.Common.Data.Repositories
{
    public class WdcStoryRepository : IRepository<WdcStory, string>
    {
        IDbConnectionFactory _dbConnFact;

        public WdcStoryRepository(IDbConnectionFactory dbConnFact)
        {
            _dbConnFact = dbConnFact;
        }

        public void Add(WdcStory entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                // TODO complete SQL
                cn.Execute(@"INSERT INTO WdcStoryRepository WHERE ",
                    entity
                    );
            }
        }

        public void Delete(WdcStory entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"DELETE WdcStoryRepository WHERE Id = @SysId", entity);
            }
        }

        public IEnumerable<WdcStory> GetAll()
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.Query<WdcStory>(@"SELECT * FROM WdcStoryRepository");
                return result;
            }
        }

        public WdcStory GetByID(string key)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.Query<WdcStory>(@"SELECT * FROM WdcStoryRepository WHERE SysId = @SysId", new { SysId = key }).First();
                return result;
            }
        }

        public void Save(WdcStory entity)
        {
            // TODO do save SQL
            throw new NotImplementedException();
        }
    }
}
