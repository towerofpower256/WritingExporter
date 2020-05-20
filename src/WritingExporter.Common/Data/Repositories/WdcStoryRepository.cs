using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Models;

namespace WritingExporter.Common.Data.Repositories
{
    public class WdcStoryRepository : IRepository<WdcStory, string>
    {
        IDbConnectionFactory _dbConnFact;
        EventHub _eventHub;

        public WdcStoryRepository(IDbConnectionFactory dbConnFact, EventHub eventHub)
        {
            _dbConnFact = dbConnFact;
            _eventHub = eventHub;
        }

        public void Add(WdcStory entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"
INSERT INTO WdcStory 
( SysId, Name, Id, Url, ShortDescription, Description, AuthorName, AuthorUsername, LastSynced, NextSync, LastUpdatedInfo, LastUpdatedChapterOutline, FirstSeen, State, StateMessage ) VALUES 
( @SysId, @Name, @Id, @Url, @ShortDescription, @Description, @AuthorName, @AuthorUsername, @LastSynced, @NextSync, @LastUpdatedInfo, @LastUpdatedChapterOutline, @FirstSeen, @State, @StateMessage );
", entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Add, new string[] { entity.SysId }, typeof(WdcStoryRepository)));
        }

        public void Delete(WdcStory entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"DELETE WdcStory WHERE SysId = @SysId;", entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Delete, new string[] { entity.SysId }, typeof(WdcStoryRepository)));
        }

        public void DeleteById(string sysId)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"DELETE WdcStory WHERE SysId = @SysId;", new { SysId = sysId });
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Delete, new string[] { sysId }, typeof(WdcChapterRepository)));
        }

        public IEnumerable<WdcStory> GetAll()
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.Query<WdcStory>(@"SELECT * FROM WdcStory;");
                return result;
            }
        }

        public WdcStory GetByID(string key)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.QueryFirstOrDefault<WdcStory>(@"SELECT * FROM WdcStory WHERE SysId = @SysId LIMIT 1;", new { SysId = key });
                return result;
            }
        }

        public void Save(WdcStory entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"
UPDATE WdcStory SET
Name = @Name, Id = @Id, Url = @Url, ShortDescription = @ShortDescription, Description = @Description, AuthorName = @AuthorName,
AuthorUsername = @AuthorUsername, LastSynced = @LastSynced, NextSync = @NextSync, LastUpdatedInfo = @LastUpdatedInfo, LastUpdatedChapterOutline = @LastUpdatedChapterOutline, 
FirstSeen = @FirstSeen, State = @State, StateMessage = @StateMessage
WHERE SysId = @SysId;", entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Update, new string[] { entity.SysId }, typeof(WdcStoryRepository)));
        }

        public WdcStory GetByStoryID(string storyId)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.QueryFirstOrDefault<WdcStory>(@"SELECT * FROM WdcStory WHERE Id = @Id LIMIT 1;", new { Id = storyId });
                return result;
            }
        }

        public IEnumerable<WdcStory> GetStoriesNeedingSync(DateTime timestamp)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.Query<WdcStory>(@"SELECT * FROM WdcStory WHERE NextSync <= @Timestamp OR NextSync IS NULL", new { Timestamp = timestamp });
            }
        }
    }
}
