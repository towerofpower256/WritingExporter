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

namespace WritingExporter.Common.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private const string DB_FILE_NAME = "WdcExporter.db";

        public DbConnectionFactory()
        {

        }

        public IDbConnection GetConnection()
        {
            if (!File.Exists(DB_FILE_NAME))
            {
                SQLiteConnection.CreateFile(DB_FILE_NAME);
                SeedDb();
            }

            var conn = new SQLiteConnection(ConnectionString);
            return conn;
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
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                // Seed database here

                conn.Execute(@"CREATE TABLE WdcStory (
                SysId CHAR(32) PRIMARY KEY,
                Name TEXT,
                Id TEXT,
                Url TEXT,
                Description TEXT,
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
                
                Content TEXT,
                IsEnd BOOLEAN,
                LastUpdated DATETIME,
                FirstSeen DATETIME
                )");

                conn.Execute(@"CREATE TABLE WdcChapterChoice
                SysId CHAR(32) PRIMARY KEY,
                ChapterId CHAR(32);
                PathLink TEXT,
                Name TEXT,
                )");
            }
        }
    }
}
