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
    public class productossController : ApiController
    {
        private Modeldb db = new Modeldb();

        // GET: api/productoss
        public IQueryable<productos> Getproductos()
        {
            return db.productos;
        }

        // GET: api/productoss/5
        [ResponseType(typeof(productos))]
        public async Task<IHttpActionResult> Getproductos(int id)
        {
            productos productos = await db.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        // PUT: api/productoss/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putproductos(int id, productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productos.id)
            {
                return BadRequest();
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(id))
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

        // POST: api/productoss
        [ResponseType(typeof(productos))]
        public async Task<IHttpActionResult> Postproductos(productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.productos.Add(productos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productos.id }, productos);
        }

        // DELETE: api/productoss/5
        [ResponseType(typeof(productos))]
        public async Task<IHttpActionResult> Deleteproductos(int id)
        {
            productos productos = await db.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            db.productos.Remove(productos);
            await db.SaveChangesAsync();

            return Ok(productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productosExists(int id)
        {
            return db.productos.Count(e => e.id == id) > 0;
        }
    }
}