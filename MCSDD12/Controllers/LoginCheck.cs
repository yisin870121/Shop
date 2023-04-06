using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MCSDD12.Controllers
{
    //繼承類別ActionFilterAttribute，前面寫一個 冒號: 就好
    public class LoginCheck:ActionFilterAttribute
    {
        //屬性
        //public bool flag { get; set; }
        //欄位
        public bool flag = true;

        public short id = 2;

        //呼叫函數LoginState
        void MemberLoginState(HttpContext context)
        {
            if (context.Session["member"] == null)
            {
                context.Response.Redirect("/Home/Login");
            }
            
        }

        void AdminLoginState(HttpContext context)
        {
            if (context.Session["user"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
            
        }


        public override void OnActionExecuting(ActionExecutingContext filterContex)
        {
            if (flag) 
            { 
                HttpContext context = HttpContext.Current;

                if (id == 1)
                    MemberLoginState(context);
                else
                    AdminLoginState(context);


            }
        }



    }
}