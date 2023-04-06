using MCSDD12.Models;
using MCSDD12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MCSDD12.Controllers
{
    public class HomeController : Controller
    {
        MCSDD12Context db = new MCSDD12Context();

        //示範錯誤訊息
        [HandleError(View ="Error")]
        public ActionResult ExceptionDemo()
        {
            int i = 0;
            int j = 100 / i;

            return View();
        }

        public ActionResult Test()
        {
            //int i = 0;
            //int j = 100 / i;

            //return View();

            //拋出例外
            throw new NotImplementedException();
        }


        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.Discontinued == false).ToList();

            return View(products);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string password = BR.getHashPassword(vMLogin.Password);

            var user = db.Members.Where(m => m.Account == vMLogin.Account && m.Password == password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View(vMLogin);
            }

            Session["member"] = user;
            return RedirectToAction("Index");

        }

        [LoginCheck(id = 1)]
        public ActionResult Logout()
        {
            Session["member"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Display(string id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var products = db.Products.Find(id);

            if (products == null)
                return HttpNotFound();

            return View(products);
        }

        //[Route(@"Products/{title}")]
        public ActionResult DisplayByTitle(string title)
        {
            if (title == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var Title = Server.UrlDecode(title);
            var products = db.Products.Where(p=>p.ProductName == Title).FirstOrDefault();

            if (products == null)
                return HttpNotFound();

            return View("Display",products);
        }

        public ActionResult MyCart()
        {
            return View();
        }
    }
}
