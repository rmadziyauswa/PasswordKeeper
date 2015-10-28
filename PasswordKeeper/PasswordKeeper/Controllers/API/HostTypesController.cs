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

namespace PasswordKeeper.Controllers.API
{
    public class HostTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/HostTypes
        public IQueryable<HostType> GetHostTypes()
        {
            return db.HostTypes;
        }

        // GET: api/HostTypes/5
        [ResponseType(typeof(HostType))]
        public IHttpActionResult GetHostType(int id)
        {
            HostType hostType = db.HostTypes.Find(id);
            if (hostType == null)
            {
                return NotFound();
            }

            return Ok(hostType);
        }

        // PUT: api/HostTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHostType(int id, HostType hostType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hostType.ID)
            {
                return BadRequest();
            }

            db.Entry(hostType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostTypeExists(id))
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

        // POST: api/HostTypes
        [ResponseType(typeof(HostType))]
        public IHttpActionResult PostHostType(HostType hostType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HostTypes.Add(hostType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hostType.ID }, hostType);
        }

        // DELETE: api/HostTypes/5
        [ResponseType(typeof(HostType))]
        public IHttpActionResult DeleteHostType(int id)
        {
            HostType hostType = db.HostTypes.Find(id);
            if (hostType == null)
            {
                return NotFound();
            }

            db.HostTypes.Remove(hostType);
            db.SaveChanges();

            return Ok(hostType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HostTypeExists(int id)
        {
            return db.HostTypes.Count(e => e.ID == id) > 0;
        }
    }
}