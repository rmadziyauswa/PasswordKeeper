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
    public class CredentialTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CredentialTypes
        public IQueryable<CredentialType> GetCredentialTypes()
        {
            return db.CredentialTypes;
        }

        // GET: api/CredentialTypes/5
        [ResponseType(typeof(CredentialType))]
        public IHttpActionResult GetCredentialType(int id)
        {
            CredentialType credentialType = db.CredentialTypes.Find(id);
            if (credentialType == null)
            {
                return NotFound();
            }

            return Ok(credentialType);
        }

        // PUT: api/CredentialTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCredentialType(int id, CredentialType credentialType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != credentialType.ID)
            {
                return BadRequest();
            }

            db.Entry(credentialType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialTypeExists(id))
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

        // POST: api/CredentialTypes
        [ResponseType(typeof(CredentialType))]
        public IHttpActionResult PostCredentialType(CredentialType credentialType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CredentialTypes.Add(credentialType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = credentialType.ID }, credentialType);
        }

        // DELETE: api/CredentialTypes/5
        [ResponseType(typeof(CredentialType))]
        public IHttpActionResult DeleteCredentialType(int id)
        {
            CredentialType credentialType = db.CredentialTypes.Find(id);
            if (credentialType == null)
            {
                return NotFound();
            }

            db.CredentialTypes.Remove(credentialType);
            db.SaveChanges();

            return Ok(credentialType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CredentialTypeExists(int id)
        {
            return db.CredentialTypes.Count(e => e.ID == id) > 0;
        }
    }
}