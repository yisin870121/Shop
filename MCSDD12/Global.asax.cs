using MCSDD12.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MCSDD12
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //啟動DB Imitializer建立資料庫

            //做好以後再將這行的註解取消掉再建置
            //Database.SetInitializer<MCSDD12Context>(new MCSDD12Initailizer());

            //若要將資料庫型態改變，須將Initailizer改完再刪掉資料庫，上面那行取消掉後建置，
            //最後隨便開一個view起來看，資料庫就會建立了


            //應用程式啟動時執行的程式碼
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
