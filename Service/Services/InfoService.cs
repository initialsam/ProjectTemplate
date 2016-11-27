using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class InfoService : IInfoService
    {
        private readonly IAppSettingRepository _appSettingRepository;

        public InfoService(IAppSettingRepository appSettingRepository)
        {
            this._appSettingRepository = appSettingRepository;
        }
        public string GetAppVersion(string appname)
        {
            string appVersion = this._appSettingRepository.GetAppVersion(appname);
            if (appVersion.Equals("0"))
            {
                appVersion = "1.0";
            }
            return appVersion;
        }
    }
}
