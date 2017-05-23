using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class S279330_UserController : Controller
    {
        private PRT405_2017SEM1Entities db = new PRT405_2017SEM1Entities();
        AccountController a = new AccountController();

        // GET: S279330_User
        public ActionResult Index()
        {
            string UserName = User.Identity.GetUserName();
            if (UserName != "")
            {
                return View(db.S279330_User.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: S279330_User/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S279330_User s279330_User = db.S279330_User.Find(id);
            if (s279330_User == null)
            {
                return HttpNotFound();
            }
            return View(s279330_User);
        }

        // GET: S279330_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: S279330_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserId,UserName,CarName,Details,Address")] S279330_User s279330_User)
        {
            if (ModelState.IsValid)
            {
                db.S279330_User.Add(s279330_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(s279330_User);
        }

        // GET: S279330_User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S279330_User s279330_User = db.S279330_User.Find(id);
            if (s279330_User == null)
            {
                return HttpNotFound();
            }
            return View(s279330_User);
        }

        // POST: S279330_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,UserName,CarName,Details,Address")] S279330_User s279330_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s279330_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s279330_User);
        }

        // GET: S279330_User/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S279330_User s279330_User = db.S279330_User.Find(id);
            if (s279330_User == null)
            {
                return HttpNotFound();
            }
            return View(s279330_User);
        }

        // POST: S279330_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            S279330_User s279330_User = db.S279330_User.Find(id);
            db.S279330_User.Remove(s279330_User);
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
