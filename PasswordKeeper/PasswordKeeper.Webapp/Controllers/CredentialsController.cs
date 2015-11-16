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
    [Authorize]
    public class CredentialsController : Controller
    {
        private PaswordEntities db = new PaswordEntities();


        // GET: Credentials
        public ActionResult Index()
        {
            var myCredentials = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name ); 

            return View(myCredentials);
        }

        public ActionResult GetByHost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var myCredentials = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name && c.HostID == id);

            return View("Index", myCredentials);
        }


        public ActionResult GetByCredentialType(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var myCredentials = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name && c.CredentialTypeID == id);

            return View("Index", myCredentials);
        }


        // GET: Credentials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name).SingleOrDefault(c => c.ID == id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // GET: Credentials/Create
        public ActionResult Create()
        {

            ViewBag.CredentialTypeID = new SelectList(db.CredentialTypes, "ID", "Name");
            ViewBag.HostID = new SelectList(db.Hosts.Include(h => h.HostType).Where(h => h.UserEmail == HttpContext.User.Identity.Name), "ID", "Name");
            return View();
        }

        // POST: Credentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CredentialTypeID,HostID,Password,DateModified,Name")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                Kommon.UpdateDateModified(credential);
                db.Credentials.Add(credential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CredentialTypeID = new SelectList(db.CredentialTypes, "ID", "Name", credential.CredentialTypeID);
            ViewBag.HostID = new SelectList(db.Hosts.Include(h => h.HostType).Where(h => h.UserEmail == HttpContext.User.Identity.Name), "ID", "Name", credential.HostID);
            return View(credential);
        }

        // GET: Credentials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name).SingleOrDefault(c => c.ID == id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            ViewBag.CredentialTypeID = new SelectList(db.CredentialTypes, "ID", "Name", credential.CredentialTypeID);
            ViewBag.HostID = new SelectList(db.Hosts.Include(h => h.HostType).Where(h => h.UserEmail == HttpContext.User.Identity.Name), "ID", "Name", credential.HostID);
            return View(credential);
        }

        // POST: Credentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CredentialTypeID,HostID,Password,DateModified,Name")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                Kommon.UpdateDateModified(credential);
                db.Entry(credential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CredentialTypeID = new SelectList(db.CredentialTypes, "ID", "Name", credential.CredentialTypeID);
            ViewBag.HostID = new SelectList(db.Hosts.Include(h => h.HostType).Where(h => h.UserEmail == HttpContext.User.Identity.Name), "ID", "Name", credential.HostID);
            return View(credential);
        }

        // GET: Credentials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name).SingleOrDefault(c => c.ID == id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // POST: Credentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Credential credential = db.Credentials.Find(id);

            //make sure this user owns this credential

            Credential myCredential = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == HttpContext.User.Identity.Name).SingleOrDefault(c => c.ID == id);

            if (myCredential==null)
            {
                return HttpNotFound();

            }

            if (credential == null)
            {
                return HttpNotFound();
            }


            db.Credentials.Remove(credential);
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
