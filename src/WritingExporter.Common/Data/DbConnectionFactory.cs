using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WritingExporter.Common.Logging;

namespace WritingExporter.Common.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private const string DB_FILE_NAME = "WdcExporter.db";

        ILogger _log;
        object _lock;

        public DbConnectionFactory(ILoggerSource loggerSource)
        {
            _lock = new object();
            _log = loggerSource.GetLogger(typeof(DbConnectionFactory));
        }

        public IDbConnection GetConnection()
        {
            lock (_lock)
            {
                if (!File.Exists(DB_FILE_NAME))
                {
                    _log.Debug("DB doesn't exist, creating new");
                    SQLiteConnection.CreateFile(DB_FILE_NAME);
                    SeedDb();
                }

                var conn = new SQLiteConnection(ConnectionString);
                return conn;
            }
        }

        private string ConnectionString
        {
            get
            {
                return $"Data Source=./{DB_FILE_NAME};Version=3;";
            }
        }

        private void SeedDb()
        {
            _log.Info("Seeding database");
            try
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    // Seed database here

                    conn.Execute(@"CREATE TABLE WdcStory (
                    SysId CHAR(32) PRIMARY KEY,
                    Name TEXT,
                    Id TEXT,
                    Url TEXT,
                    AuthorName TEXT,
                    AuthorUsername TEXT,
                    ShortDescription TEXT,
                    Description TEXT,
                    LastSynced DATETIME,
                    NextSync DATETIME,
                    LastUpdatedInfo DATETIME,
                    LastUpdatedChapterOutline DATETIME,
                    FirstSeen DATETIME,
                    State INT,
                    StateMessage TEXT
                    )");

                    conn.Execute(@"CREATE TABLE WdcChapter (
                    SysId CHAR(32) PRIMARY KEY,
                    StoryId CHAR(32) NOT NULL,
                    Path TEXT,
                    Title TEXT,
                    SourceChoiceTitle TEXT,
                    AuthorName TEXT,
                    AuthorUsername TEXT,
                    Content TEXT,
                    IsEnd BOOLEAN,
                    LastSynced DATETIME,
                    LastUpdated DATETIME,
                    FirstSeen DATETIME,
                    ChoicesString TEXT
                    )");

                    conn.Execute(@"CREATE TABLE WdcChapterChoice (
                    SysId CHAR(32) PRIMARY KEY,
                    ChapterId CHAR(32),
                    PathLink TEXT,
                    Name TEXT
                    )");

                    conn.Execute(@"CREATE INDEX WdcChapterChoice_ChapterId on WdcChapterChoice(ChapterId);");
                    conn.Execute(@"CREATE INDEX WdcChapter_StoryId on WdcChapter(StoryId);");
                    conn.Execute(@"CREATE INDEX WdcStory_Id on WdcStory(Id);");
                    // TODO might need some more indexes for story / chapter states & timestamps
                }
            }
            catch (Exception ex)
            {
                // Delete the database if an exception occurrs while seeind
                File.Delete(DB_FILE_NAME);

                throw ex;
            }
            
        }
    }
}
