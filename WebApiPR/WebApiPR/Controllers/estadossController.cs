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
    public class estadossController : ApiController
    {
        private Modeldb db = new Modeldb();

        // GET: api/estadoss
        public IQueryable<estados> Getestados()
        {
            return db.estados;
        }

        // GET: api/estadoss/5
        [ResponseType(typeof(estados))]
        public async Task<IHttpActionResult> Getestados(int id)
        {
            estados estados = await db.estados.FindAsync(id);
            if (estados == null)
            {
                return NotFound();
            }

            return Ok(estados);
        }

        // PUT: api/estadoss/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putestados(int id, estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados.id)
            {
                return BadRequest();
            }

            db.Entry(estados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estadosExists(id))
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

        // POST: api/estadoss
        [ResponseType(typeof(estados))]
        public async Task<IHttpActionResult> Postestados(estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.estados.Add(estados);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (estadosExists(estados.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estados.id }, estados);
        }

        // DELETE: api/estadoss/5
        [ResponseType(typeof(estados))]
        public async Task<IHttpActionResult> Deleteestados(int id)
        {
            estados estados = await db.estados.FindAsync(id);
            if (estados == null)
            {
                return NotFound();
            }

            db.estados.Remove(estados);
            await db.SaveChangesAsync();

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool estadosExists(int id)
        {
            return db.estados.Count(e => e.id == id) > 0;
        }
    }
}