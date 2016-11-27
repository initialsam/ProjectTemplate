using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MainController : Controller
    {
        private readonly IInfoService _infoService;

        public MainController(IInfoService infoService)
        {
            this._infoService = infoService;
        }
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string appname)
        {
            ViewBag.AppVersion = this._infoService.GetAppVersion(appname);
            return View();
        }
        public ActionResult Exception()
        {
            throw new ApplicationException(Guid.NewGuid().ToString());
        }
         
    }
}