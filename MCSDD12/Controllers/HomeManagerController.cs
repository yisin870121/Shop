using MCSDD12.Models;
using MCSDD12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCSDD12.Controllers
{
    public class HomeManagerController : Controller
    {
        MCSDD12Context db = new MCSDD12Context();

        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string password = BR.getHashPassword(vMLogin.Password);

            var user = db.Employees.Where(m => m.Account == vMLogin.Account && m.Password == password).FirstOrDefault();
            
            if(user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View(vMLogin);
            }

            Session["user"] = user;
            return RedirectToAction("Index");
            
        }

        [LoginCheck]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}