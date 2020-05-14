using Dapper;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Models;

namespace WritingExporter.Common.Data.Repositories
{
    public class WdcChapterRepository : IRepository<WdcChapter, string>
    {
        const string SQL_INSERT = @"
INSERT INTO WdcChapter
( SysId, StoryId, Path, Title, SourceChoiceTitle, AuthorName, AuthorUsername, Content, IsEnd, LastSynced, LastUpdated, FirstSeen, ChoicesString) VALUES 
( @SysId, @StoryId, @Path, @Title, @SourceChoiceTitle, @AuthorName, @AuthorUsername, @Content, @IsEnd, @LastSynced, @LastUpdated, @FirstSeen, @ChoicesString );
";
        
        IDbConnectionFactory _dbConnFact;
        EventHub _eventHub;

        public WdcChapterRepository(IDbConnectionFactory dbConnFact, EventHub eventHub)
        {
            _dbConnFact = dbConnFact;
            _eventHub = eventHub;
        }

        public void Add(WdcChapter entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(SQL_INSERT, entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Add, new string[] { entity.SysId }, typeof(WdcChapterRepository)));
        }

        public void AddRange(IEnumerable<WdcChapter> chapters)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();

                using (IDbTransaction tx = cn.BeginTransaction())
                {
                    foreach (var story in chapters)
                    {
                        cn.Execute(SQL_INSERT, story);
                    }

                    tx.Commit();
                }
            }

            // Insert completed, trigger events for all
            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Add, chapters.Select(e => e.SysId), typeof(WdcChapterRepository)));
        }

        public void Delete(WdcChapter entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"DELETE WdcChapter WHERE SysId = @SysId;", entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Delete, new string[] { entity.SysId }, typeof(WdcChapterRepository)));
        }

        public void DeleteById(string sysId)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"DELETE WdcChapter WHERE SysId = @SysId;", new { SysId = sysId });
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Delete, new string[] { sysId }, typeof(WdcChapterRepository)));
        }

        public IEnumerable<WdcChapter> GetAll()
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.Query<WdcChapter>(@"SELECT * FROM WdcChapter;");
                return result;
            }
        }

        public WdcChapter GetByID(string key)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                var result = cn.QueryFirstOrDefault<WdcChapter>(@"SELECT * FROM WdcChapter WHERE SysId = @SysId LIMIT 1;", new { SysId = key });
                return result;
            }
        }

        public void Save(WdcChapter entity)
        {
            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                cn.Execute(@"
UPDATE WdcChapter SET
SysId = @SysId, StoryId = @StoryId, Path = @Path, Title = @Title, SourceChoiceTitle = @SourceChoiceTitle,
AuthorName = @AuthorName, AuthorUsername = @AuthorUsername, Content = @Content, IsEnd = @IsEnd, 
LastSynced = @LastSynced, LastUpdated = @LastUpdated, FirstSeen = @FirstSeen,
ChoicesString = @ChoicesString
WHERE SysId = @SysId;", entity);
            }

            _eventHub.PublishEvent(new RepositoryChangedEvent(RepositoryChangedEventType.Update, new string[] { entity.SysId }, typeof(WdcChapterRepository)));
        }

        // Get a chapter list for a story
        public IEnumerable<WdcChapter> GetStoryChapters(string storySysId)
        {
            // Handle invalid inputs
            if (string.IsNullOrEmpty(storySysId))
                return new WdcChapter[0];

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.Query<WdcChapter>(@"SELECT * FROM WdcChapter WHERE StoryId = @StoryId;",
                    new { StoryId = storySysId });
            }
        }

        public IEnumerable<WdcChapterOutline> GetStoryOutline(string storySysId)
        {
            // Handle invalid inputs
            if (string.IsNullOrEmpty(storySysId))
                return new WdcChapterOutline[0];

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.Query<WdcChapterOutline>(@"SELECT SysId, StoryId, Path, Title, LastSynced, LastUpdated, FirstSeen FROM WdcChapter WHERE StoryId = @StoryId;",
                    new { StoryId = storySysId });
            }
        }

        // Get a chapter count for a story
        public int GetStoryChaptersCount(string storySysId)
        {
            // Handle invalid inputs
            if (string.IsNullOrEmpty(storySysId))
                return 0;

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.ExecuteScalar<int>(@"SELECT COUNT(*) FROM WdcChapter WHERE StoryId = @StoryId;",
                    new { StoryId = storySysId });
            }
        }



        // Get a list of chapters for a story that haven't been updated since the timestamp
        public IEnumerable<WdcChapter> GetStoryChapterNotSyncedSince(string storySysId, DateTime timestamp)
        {
            // Handle invalid inputs
            if (string.IsNullOrEmpty(storySysId) || timestamp == DateTime.MinValue)
                return new WdcChapter[0];

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.Query<WdcChapter>(@"SELECT * FROM WdcChapter WHERE StoryId = @StoryId AND ( LastSynced <= @Timestamp OR LastSynced IS NULL );",
                    new { StoryId = storySysId, Timestamp = timestamp }).ToArray();
            }
        }

        // Get a count of chapters for a story that haven't been updated since the timestamp
        public int GetStoryChapterNotSyncedSinceCount(string storySysId, DateTime timestamp)
        {
            // Handle invalid inputs
            if (string.IsNullOrEmpty(storySysId) || timestamp == DateTime.MinValue)
                return 0;

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.ExecuteScalar<int>(@"SELECT COUNT(*) FROM WdcChapter WHERE StoryId = @StoryId AND ( LastSynced <= @Timestamp OR LastSynced IS NULL );",
                    new { StoryId = storySysId, Timestamp = timestamp });
            }
        }

        public DateTime GetStoryLastUpdatedChaper(string storySysId)
        {
            if (string.IsNullOrEmpty(storySysId))
                throw new ArgumentNullException("storySysId");

            using (IDbConnection cn = _dbConnFact.GetConnection())
            {
                cn.Open();
                return cn.ExecuteScalar<DateTime>(@"SELECT MAX(LastUpdated) FROM WdcChapter WHERE StoryId = @StoryId;",
                    new { StoryId = storySysId });
            }
        }
    }
}
