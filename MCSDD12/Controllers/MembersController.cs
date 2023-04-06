using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSDD12.Models;
using PagedList;

namespace MCSDD12.Controllers
{
    //[LoginCheck]
    public class MembersController : Controller
    {
        private MCSDD12Context db = new MCSDD12Context();
        SetData setdata = new SetData();

        //換分頁的寫法
        //每一頁有幾筆資料
        int pageSize = 10; 

        public ActionResult Index(int page=1)
        {
            //預設的頁數:第一頁
            //小於1就給1，否則就給page
            int currentPage = page < 1 ? 1 : page;

            var member = db.Members.ToList();

            //現在是第幾頁,每一頁幾筆資料
            var result = member.ToPagedList(currentPage, pageSize);

            return View(result);
        }

        //[ChildActionOnly]
        public ActionResult _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return PartialView(members);
        }

        // GET: Members/Create
        public ActionResult _Create()
        {
            return PartialView();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Members members)
        {
            if (ModelState.IsValid)
            {
                string sql = "insert into Members(MemberName,MemberPhotoFile,MemberBirthday,CreatedDate,Account,Password)values(@MemberName,@MemberPhotoFile,@MemberBirthday,@CreatedDate,@Account,@Password)";

                List<SqlParameter> list = new List<SqlParameter>
                {
                    new SqlParameter("MemberName",members.MemberName),
                    new SqlParameter("MemberPhotoFile",members.MemberPhotoFile),
                    new SqlParameter("MemberBirthday",members.MemberBirthday),
                    new SqlParameter("CreatedDate",members.CreatedDate),
                    new SqlParameter("Account",members.Account),
                    new SqlParameter("Password",members.Password)

                };

                setdata.executeSql(sql, list);
            
                //db.Members.Add(members);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult _Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return PartialView(members);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Members members)
        {
            string sql = "update members set MemberName=@MemberName, MemberBirthday=@MemberBirthday where MemberID=@MemberID";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("MemberID",members.MemberID),
                new SqlParameter("MemberName",members.MemberName),
                new SqlParameter("MemberBirthday",members.MemberBirthday)
            };

            try 
            {
                setdata.executeSql(sql, list);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Msg= ex.Message;
                return View(members);
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(members).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
