using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MCSDD12
{
    //路徑的組態//預設的網站位置
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //預設的路由擺在最下面

            routes.MapRoute(
                name: "Cart",
                url: "購物車",
                defaults: new { controller = "Home", action = "MyCart" }
            );

            routes.MapRoute(
                name: "Cart2",
                url: "我的購物車",
                defaults: new { controller = "Home", action = "MyCart" }
            );

            routes.MapRoute(
                name: "ProductDisplay",
                url: "Products/{id}",
                defaults: new { controller = "Home", action = "DisplayByTitle" }
            );

            //這個是啟用自訂路由的方法
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
