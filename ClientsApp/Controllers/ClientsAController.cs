using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClientsApp.Models;


namespace ClientsApp.Controllers
{
    public class ClientsAController : Controller
    {
        private DBentities db = new DBentities();

        // GET: ClientsA
        public ActionResult Index()
        {
            return View(db.ClientsTables.ToList());
        }
        // GET: ClientsA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            if (clientsTable == null)
            {
                return HttpNotFound();
            }
            return View(clientsTable);
        }

        // GET: ClientsA/Create ...
        public ActionResult Create()
        {
            return View();
        }

        

        // POST: ClientsA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Age,Gender")] ClientsTable clientsTable)
        {
            if (ModelState.IsValid)
            {
                db.ClientsTables.Add(clientsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientsTable);
        }

        // GET: ClientsA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            if (clientsTable == null)
            {
                return HttpNotFound();
            }
            return View(clientsTable);
        }

        // POST: ClientsA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Age,Gender")] ClientsTable clientsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientsTable);
        }

        // GET: ClientsA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            if (clientsTable == null)
            {
                return HttpNotFound();
            }
            return View(clientsTable);
        }

        // POST: ClientsA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientsTable clientsTable = db.ClientsTables.Find(id);
            db.ClientsTables.Remove(clientsTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
