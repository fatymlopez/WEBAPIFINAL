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
    public class detallereservacionsController : ApiController
    {
        private Modeldb db = new Modeldb();

        // GET: api/detallereservacions
        public IQueryable<detallereservacion> Getdetallereservacion()
        {
            return db.detallereservacion;
        }

        // GET: api/detallereservacions/5
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Getdetallereservacion(int id)
        {
            detallereservacion detallereservacion = await db.detallereservacion.FindAsync(id);
            if (detallereservacion == null)
            {
                return NotFound();
            }

            return Ok(detallereservacion);
        }

        // PUT: api/detallereservacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdetallereservacion(int id, detallereservacion detallereservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallereservacion.idreservacion)
            {
                return BadRequest();
            }

            db.Entry(detallereservacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detallereservacionExists(id))
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

        // POST: api/detallereservacions
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Postdetallereservacion(detallereservacion detallereservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.detallereservacion.Add(detallereservacion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (detallereservacionExists(detallereservacion.idreservacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detallereservacion.idreservacion }, detallereservacion);
        }

        // DELETE: api/detallereservacions/5
        [ResponseType(typeof(detallereservacion))]
        public async Task<IHttpActionResult> Deletedetallereservacion(int id)
        {
            detallereservacion detallereservacion = await db.detallereservacion.FindAsync(id);
            if (detallereservacion == null)
            {
                return NotFound();
            }

            db.detallereservacion.Remove(detallereservacion);
            await db.SaveChangesAsync();

            return Ok(detallereservacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool detallereservacionExists(int id)
        {
            return db.detallereservacion.Count(e => e.idreservacion == id) > 0;
        }
    }
}