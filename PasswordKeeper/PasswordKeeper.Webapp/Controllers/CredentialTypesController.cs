using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PasswordKeeper.Webapp.Models.EntityModel;
using PasswordKeeper.Webapp.Models.Logic;

namespace PasswordKeeper.Webapp.Controllers
{
    public class CredentialTypesController : Controller
    {
        private PaswordEntities db = new PaswordEntities();

        // GET: CredentialTypes
        public ActionResult Index()
        {
            return View(db.CredentialTypes.ToList());
        }

        // GET: CredentialTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredentialType credentialType = db.CredentialTypes.Find(id);
            if (credentialType == null)
            {
                return HttpNotFound();
            }
            return View(credentialType);
        }

        // GET: CredentialTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CredentialTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateModified")] CredentialType credentialType)
        {
            if (ModelState.IsValid)
            {
                Kommon.UpdateDateModified(credentialType);
                db.CredentialTypes.Add(credentialType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credentialType);
        }

        // GET: CredentialTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredentialType credentialType = db.CredentialTypes.Find(id);
            if (credentialType == null)
            {
                return HttpNotFound();
            }
            return View(credentialType);
        }

        // POST: CredentialTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateModified")] CredentialType credentialType)
        {
            if (ModelState.IsValid)
            {
                Kommon.UpdateDateModified(credentialType);

                db.Entry(credentialType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credentialType);
        }

        // GET: CredentialTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredentialType credentialType = db.CredentialTypes.Find(id);
            if (credentialType == null)
            {
                return HttpNotFound();
            }
            return View(credentialType);
        }

        // POST: CredentialTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CredentialType credentialType = db.CredentialTypes.Find(id);
            db.CredentialTypes.Remove(credentialType);
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
