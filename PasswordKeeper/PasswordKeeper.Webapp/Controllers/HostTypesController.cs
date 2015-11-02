using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PasswordKeeper.Webapp.Models.EntityModel;

namespace PasswordKeeper.Webapp.Controllers
{
    public class HostTypesController : Controller
    {
        private PaswordEntities db = new PaswordEntities();

        // GET: HostTypes
        public ActionResult Index()
        {
            return View(db.HostTypes.ToList());
        }

        // GET: HostTypes/Details/5
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

        // GET: HostTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostTypes/Create
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

        // GET: HostTypes/Edit/5
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

        // POST: HostTypes/Edit/5
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

        // GET: HostTypes/Delete/5
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

        // POST: HostTypes/Delete/5
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
