using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiPR.Models;

namespace WebApiPR.Controllers
{
    public class usuappsController : ApiController
    {
        private Modeldb db = new Modeldb();

        // GET: api/usuapps
        public IQueryable<usuapp> Getusuapp()
        {
            return db.usuapp;
        }

        // GET: api/usuapps/5
        [ResponseType(typeof(usuapp))]
        public async Task<IHttpActionResult> Getusuapp(int id)
        {
            usuapp usuapp = await db.usuapp.FindAsync(id);
            if (usuapp == null)
            {
                return NotFound();
            }

            return Ok(usuapp);
        }

        // PUT: api/usuapps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putusuapp(int id, usuapp usuapp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuapp.id)
            {
                return BadRequest();
            }

            db.Entry(usuapp).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuappExists(id))
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

        // POST: api/usuapps
        [ResponseType(typeof(usuapp))]
        public async Task<IHttpActionResult> Postusuapp(usuapp usuapp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuapp.Add(usuapp);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuapp.id }, usuapp);
        }

        // DELETE: api/usuapps/5
        [ResponseType(typeof(usuapp))]
        public async Task<IHttpActionResult> Deleteusuapp(int id)
        {
            usuapp usuapp = await db.usuapp.FindAsync(id);
            if (usuapp == null)
            {
                return NotFound();
            }

            db.usuapp.Remove(usuapp);
            await db.SaveChangesAsync();

            return Ok(usuapp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuappExists(int id)
        {
            return db.usuapp.Count(e => e.id == id) > 0;
        }
    }
}