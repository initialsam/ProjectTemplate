using Dapper;
using EF.Diagnostics.Profiling;
using EF.Diagnostics.Profiling.Data;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BaseRepository
    {
        //DB 是用 SQLite
        //若要查看資料可以用
        //firefox https://addons.mozilla.org/zh-tw/firefox/addon/sqlite-manager/
        public BaseRepository()
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }
        }

        public static string DbFile
        {
            get { return "D:\\SimpleDb.sqlite"; }
        }

        public static IDbConnection SimpleDbConnection()
        {
            var conn = new SQLiteConnection("Data Source=" + DbFile);
            var dbProfiler = new DbProfiler(ProfilingSession.Current.Profiler);
            return new ProfiledDbConnection(conn, dbProfiler);
        }

        private static void CreateDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                cnn.Execute(
                    @"CREATE TABLE Customer
                      (
                         ID                                  integer primary key AUTOINCREMENT,
                         FirstName                           nvarchar(100) not null,
                         LastName                            nvarchar(100) not null,
                         DateOfBirth                         datetime not null
                      );

                      CREATE TABLE AppInfo
                      (
                         ID                                  integer primary key AUTOINCREMENT,
                         AppName                             nvarchar(100) not null,
                         Version                             nvarchar(100) not null,
                         Description                         nvarchar(100) not null,
                         Date                                datetime not null
                      );

                        INSERT INTO AppInfo 
                        ( AppName, Version, Description, Date ) 
                        VALUES 
                        ( 'WAR', '0.01c', '產生未來日記',datetime('now', 'localtime') );
                        
                        INSERT INTO AppInfo 
                        ( AppName, Version, Description, Date ) 
                        VALUES 
                        ( 'C#Book', '8.7', '好用',datetime('now', 'localtime') )
                        "
                    );
            }
        }
    }
}
