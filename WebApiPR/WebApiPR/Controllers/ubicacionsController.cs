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
    public class ubicacionsController : ApiController
    {
        private Modeldb db = new Modeldb();

        // GET: api/ubicacions
        public IQueryable<ubicacion> Getubicacion()
        {
            return db.ubicacion;
        }

        // GET: api/ubicacions/5
        [ResponseType(typeof(ubicacion))]
        public async Task<IHttpActionResult> Getubicacion(int id)
        {
            ubicacion ubicacion = await db.ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/ubicacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putubicacion(int id, ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubicacion.id)
            {
                return BadRequest();
            }

            db.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ubicacionExists(id))
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

        // POST: api/ubicacions
        [ResponseType(typeof(ubicacion))]
        public async Task<IHttpActionResult> Postubicacion(ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ubicacion.Add(ubicacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ubicacion.id }, ubicacion);
        }

        // DELETE: api/ubicacions/5
        [ResponseType(typeof(ubicacion))]
        public async Task<IHttpActionResult> Deleteubicacion(int id)
        {
            ubicacion ubicacion = await db.ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            db.ubicacion.Remove(ubicacion);
            await db.SaveChangesAsync();

            return Ok(ubicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ubicacionExists(int id)
        {
            return db.ubicacion.Count(e => e.id == id) > 0;
        }
    }
}