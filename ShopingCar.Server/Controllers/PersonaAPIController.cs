﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopingCar.Server.Models;

namespace ShopingCar.Server.Controllers
{
    public class PersonaAPIController : ApiController
    {
        private ShopingCarServerContext db = new ShopingCarServerContext();

        // GET: api/PersonaAPI
        public IQueryable<Persona> GetPersonas()
        {
            return db.Personas;
        }

        // GET: api/PersonaAPI/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(int id)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/PersonaAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/PersonaAPI
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personas.Add(persona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/PersonaAPI/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(int id)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Personas.Remove(persona);
            db.SaveChanges();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Personas.Count(e => e.Id == id) > 0;
        }
    }
}