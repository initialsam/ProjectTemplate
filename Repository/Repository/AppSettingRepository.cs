using Common.DataTransferObject;
using Dapper;
using EF.Diagnostics.Profiling;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AppSettingRepository : BaseRepository, IAppSettingRepository
    {
        public AppSettingRepository()
        {
        }
        public string GetAppVersion(string appName)
        {
            
            using (var cnn = SimpleDbConnection())
            {
                var sql = @"
                SELECT  ID ,AppName, Version, Description, Date
                FROM    AppInfo
                WHERE   AppName = @AppName
            ";
                var result = cnn.Query<AppInfoDto>(sql, new { AppName = appName });
                if (result.Any() == false)
                {
                    throw new Exception($"找不到{appName}的Version");
                }

                return result.Single().Version;
            }
            
        }
    }
}
