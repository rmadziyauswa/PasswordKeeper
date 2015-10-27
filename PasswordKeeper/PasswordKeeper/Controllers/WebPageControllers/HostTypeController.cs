using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PasswordKeeper.Models.DAL;
using PasswordKeeper.Models.Logic;

namespace PasswordKeeper.Controllers.WebPageControllers
{
    public class HostTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HostType
        public ActionResult Index()
        {
            return View(db.HostTypes.ToList());
        }

        // GET: HostType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostType hostType = db.HostTypes.Find(id);
            if (hostType == null)
            {
                return HttpNotFound();
            }
            return View(hostType);
        }

        // GET: HostType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DateModified")] HostType hostType)
        {
            if (ModelState.IsValid)
            {
                db.HostTypes.Add(hostType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostType);
        }

        // GET: HostType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostType hostType = db.HostTypes.Find(id);
            if (hostType == null)
            {
                return HttpNotFound();
            }
            return View(hostType);
        }

        // POST: HostType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DateModified")] HostType hostType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hostType);
        }

        // GET: HostType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostType hostType = db.HostTypes.Find(id);
            if (hostType == null)
            {
                return HttpNotFound();
            }
            return View(hostType);
        }

        // POST: HostType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostType hostType = db.HostTypes.Find(id);
            db.HostTypes.Remove(hostType);
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
