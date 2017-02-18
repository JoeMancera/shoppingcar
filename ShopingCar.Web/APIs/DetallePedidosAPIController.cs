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
using ShopingCar.Web.Models;

namespace ShopingCar.Web.APIs
{
    public class DetallePedidosAPIController : ApiController
    {
        private ShopingCarWebContext db = new ShopingCarWebContext();

        // GET: api/DetallePedidosAPI
        public IQueryable<DetallePedido> GetDetallePedidoes()
        {
            return db.DetallePedidoes;
        }

        // GET: api/DetallePedidosAPI/5
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult GetDetallePedido(int id)
        {
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return Ok(detallePedido);
        }

        // PUT: api/DetallePedidosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallePedido.Id)
            {
                return BadRequest();
            }

            db.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        // POST: api/DetallePedidosAPI
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult PostDetallePedido(DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallePedidoes.Add(detallePedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detallePedido.Id }, detallePedido);
        }

        // DELETE: api/DetallePedidosAPI/5
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult DeleteDetallePedido(int id)
        {
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            db.DetallePedidoes.Remove(detallePedido);
            db.SaveChanges();

            return Ok(detallePedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallePedidoExists(int id)
        {
            return db.DetallePedidoes.Count(e => e.Id == id) > 0;
        }
    }
}