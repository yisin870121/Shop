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
            //�Ұ�DB Imitializer�إ߸�Ʈw

            //���n�H��A�N�o�檺���Ѩ������A�ظm
            //Database.SetInitializer<MCSDD12Context>(new MCSDD12Initailizer());

            //�Y�n�N��Ʈw���A���ܡA���NInitailizer�粒�A�R����Ʈw�A�W�������������ظm�A
            //�̫��H�K�}�@��view�_�ӬݡA��Ʈw�N�|�إߤF


            //���ε{���Ұʮɰ��檺�{���X
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
