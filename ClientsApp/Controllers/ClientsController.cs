using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientsApp.Models;

namespace ClientsApp.Controllers
{
    public class ClientsController : Controller
    {
        private DBentities db = new DBentities();

        // GET: Clients
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "fn_desc" : "";
            //  ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var cli = from s in db.ClientsTables
                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cli = cli.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fn_desc":
                    cli = cli.OrderByDescending(s => s.LastName);
                    break;
                case "ln_desc":
                    cli = cli.OrderByDescending(s => s.FirstName);
                    break;

                default:
                    cli = cli.OrderBy(s => s.LastName);
                    break;
            }

            return View(cli.ToList());
        }

        // GET: Clients/Details/5
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

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Age")] ClientsTable clientsTable)
        {
            if (ModelState.IsValid)
            {
                db.ClientsTables.Add(clientsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientsTable);
        }

        // GET: Clients/Edit/5
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

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Age")] ClientsTable clientsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientsTable);
        }

        // GET: Clients/Delete/5
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

        // POST: Clients/Delete/5
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
