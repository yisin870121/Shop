using MCSDD12.Controllers;
using System.Web;
using System.Web.Mvc;

namespace MCSDD12
{
    //過濾器//如果發生錯誤出現系統錯誤訊息，可以呈現另一個自己設定的畫面
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                View = "Error2"
            });

            filters.Add(new LogReport());
        }
    }
}
