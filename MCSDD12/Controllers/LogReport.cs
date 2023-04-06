using MCSDD12.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace MCSDD12.Controllers
{
    //ActionFilterAttribute要using System.Web.Mvc;這個，不是using System.Web.Http.Filters;
    public class LogReport : ActionFilterAttribute
    {
        public bool flag = true;
        HttpContext context;

        void LogValues(RouteData routeData, HttpContext context)
        {
            var logTimeStamp = DateTime.Now;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var parameter = routeData.Values["id"] == null ? "N/A" : routeData.Values["id"];
            var user = getUser();
            
            // \反斜線是根目錄
            StreamWriter sw = new StreamWriter(context.Server.MapPath("\\ValueLog.csv"), true, Encoding.Default);

            //WriteLine是一次寫一行
            sw.WriteLine(logTimeStamp + "," + controllerName + "," + actionName + "," + parameter+ "," + user);
            sw.Close();
        }

        void RequestLog(HttpContext context)
        {
            var ip = context.Request.ServerVariables["REMOTE_ADDR"];
            var host = context.Request.ServerVariables["REMOTE_HOST"];
            var browser = context.Request.ServerVariables["HTTP_USER_AGENT"];

            var requestType = context.Request.RequestType;
            var userAgent = context.Request.UserAgent;
            var userHostAddress = context.Request.UserHostAddress;
            var userHostName = context.Request.UserHostName;
            var httpMethod = context.Request.HttpMethod;
            var logTimeStamp = DateTime.Now;

            var user = getUser();

            StreamWriter sw = new StreamWriter(context.Server.MapPath("\\RequestLog.txt"), true, Encoding.Default);

            sw.WriteLine(logTimeStamp + "," + ip + "," + host + "," + browser + ","
                + requestType +","+ userAgent + "," + userHostAddress + "," + userHostName + "," + httpMethod + "," + user);
            sw.Close();
        }

        string getUser()
        {
            var user = "Guest";
            if (context.Session["user"] != null)
            {
                user = ((Employees)context.Session["user"]).EmployeeID + ((Employees)context.Session["user"]).EmployeeName;
            }
            else if (context.Session["member"] != null)
            {
                user = ((Members)context.Session["member"]).MemberID + ((Members)context.Session["member"]).MemberName;
            }

            return user;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                context = HttpContext.Current;

                LogValues(filterContext.RouteData, context);
            }
            
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (flag)
            {
                context = HttpContext.Current;

                RequestLog(context);
            }

        }
    }
}