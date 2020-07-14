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
    public class ClientsTablesController : ApiController
    {
        private DBentities db = new DBentities();

        // GET: api/ClientsTables
        public IQueryable<ClientsTable> GetClientsTables()
        {
            return db.ClientsTables;
        }

        // GET: api/ClientsTables/5
        [ResponseType(typeof(ClientsTable))]
        public IHttpActionResult GetClientsTable(int id)
        {
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            if (clientsTable == null)
            {
                return NotFound();
            }

            return Ok(clientsTable);
        }

        // PUT: api/ClientsTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientsTable(int id, ClientsTable clientsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientsTable.ID)
            {
                return BadRequest();
            }

            db.Entry(clientsTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsTableExists(id))
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

        // POST: api/ClientsTables
        [ResponseType(typeof(ClientsTable))]
        public IHttpActionResult PostClientsTable(ClientsTable clientsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientsTables.Add(clientsTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientsTable.ID }, clientsTable);
        }

        // DELETE: api/ClientsTables/5
        [ResponseType(typeof(ClientsTable))]
        public IHttpActionResult DeleteClientsTable(int id)
        {
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            if (clientsTable == null)
            {
                return NotFound();
            }

            db.ClientsTables.Remove(clientsTable);
            db.SaveChanges();

            return Ok(clientsTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsTableExists(int id)
        {
            return db.ClientsTables.Count(e => e.ID == id) > 0;
        }
    }
}