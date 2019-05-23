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
    public class reservacionsController : ApiController
    {
        private ModelFinal db = new ModelFinal();
        public reservacionsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = true;
        }

        // GET: api/reservacions
        public IQueryable<reservacion> Getreservacion()
        {
            //return db.reservacion;
            return db.reservacion.Include(dbreserva => dbreserva.detallereservacion).Include(dbreserva => dbreserva.cliente).Include(dbreserva => dbreserva.ubicacion);
        }

        // GET: api/reservacions/5
        [ResponseType(typeof(reservacion))]
        public async Task<IHttpActionResult> Getreservacion(int id)
        {
            reservacion reservacion = await db.reservacion.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return Ok(reservacion);
        }

        // PUT: api/reservacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putreservacion(int id, reservacion reservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservacion.id)
            {
                return BadRequest();
            }

            db.Entry(reservacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservacionExists(id))
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

        // POST: api/reservacions
        [ResponseType(typeof(reservacion))]
        public async Task<IHttpActionResult> Postreservacion(reservacion reservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reservacion.Add(reservacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reservacion.id }, reservacion);
        }

        // DELETE: api/reservacions/5
        [ResponseType(typeof(reservacion))]
        public async Task<IHttpActionResult> Deletereservacion(int id)
        {
            reservacion reservacion = await db.reservacion.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            db.reservacion.Remove(reservacion);
            await db.SaveChangesAsync();

            return Ok(reservacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reservacionExists(int id)
        {
            return db.reservacion.Count(e => e.id == id) > 0;
        }
    }
}