using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PasswordKeeper.Models.DAL;
using PasswordKeeper.Models.Logic;
using System.Web;
using System.Threading;

namespace PasswordKeeper.Controllers.API
{
    public class HostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Hosts
        public IQueryable<Host> GetHosts()
        {


            return db.Hosts;
        }

        // GET: api/Hosts/5
        [ResponseType(typeof(Host))]
        public IHttpActionResult GetHost(int id)
        {
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return NotFound();
            }

            return Ok(host);
        }

        // PUT: api/Hosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHost(int id, Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != host.ID)
            {
                return BadRequest();
            }

            db.Entry(host).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hosts
        [ResponseType(typeof(Host))]
        public IHttpActionResult PostHost(Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hosts.Add(host);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            

            return CreatedAtRoute("DefaultApi", new { id = host.ID }, host);
        }

        // DELETE: api/Hosts/5
        [ResponseType(typeof(Host))]
        public IHttpActionResult DeleteHost(int id)
        {
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return NotFound();
            }

            db.Hosts.Remove(host);
            db.SaveChanges();

            return Ok(host);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HostExists(int id)
        {
            return db.Hosts.Count(e => e.ID == id) > 0;
        }
    }
}