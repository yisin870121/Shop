using MCSDD12.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace MCSDD12.Controllers
{
    [LoginCheck(id =1)]
    public class MemberOrderController : Controller
    {
        MCSDD12Context db = new MCSDD12Context();

        public ActionResult Order()
        {
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia");
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName");
            ViewBag.OrderDate = DateTime.Today.ToShortDateString();

            //隨機取一個處理訂單的員工
            int endNum = db.Employees.Count();
            Random r = new Random();
            
            ViewBag.Employee = db.Employees.OrderBy(m=>m.EmployeeID).Skip(r.Next(endNum)).Take(1).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult Order(Orders orders,string cartData)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("ShipName",orders.ShipName),
                new SqlParameter("ShipAddress",orders.ShipAddress),
                new SqlParameter("ShipID",orders.ShipID),
                new SqlParameter("PayTypeID",orders.PayTypeID),
                new SqlParameter("MemberID",((Members)Session["member"]).MemberID),
                new SqlParameter("EmployeeID",orders.EmployeeID),
                new SqlParameter("cart",cartData)
            };

            SetData sd = new SetData();
            sd.executeSqlBySP("addOrders", list);
            TempData["cartFlag"] = "OK";

            return RedirectToAction("MyOrderList");
        }

        public ActionResult MyOrderList()
        {
            var memID = ((Members)Session["member"]).MemberID;
            var orders = db.Orders.Where(m => m.MemberID == memID).ToList();
            
            return View(orders);
        }
    }
}