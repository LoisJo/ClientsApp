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
using ClientsApp.Models;

namespace ClientsApp.Controllers
{
    public class MoviesTableController : ApiController
    {
        private DBentities db = new DBentities();

        // GET: api/Movies1
        public IQueryable<Movy> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies1/5
        [ResponseType(typeof(Movy))]
        public IHttpActionResult GetMovy(int id)
        {
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return NotFound();
            }

            return Ok(movy);
        }

        // PUT: api/Movies1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovy(int id, Movy movy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movy.ID)
            {
                return BadRequest();
            }

            db.Entry(movy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovyExists(id))
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

        // POST: api/Movies1
        [ResponseType(typeof(Movy))]
        public IHttpActionResult PostMovy(Movy movy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movy.ID }, movy);
        }

        // DELETE: api/Movies1/5
        [ResponseType(typeof(Movy))]
        public IHttpActionResult DeleteMovy(int id)
        {
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movy);
            db.SaveChanges();

            return Ok(movy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovyExists(int id)
        {
            return db.Movies.Count(e => e.ID == id) > 0;
        }
    }
}