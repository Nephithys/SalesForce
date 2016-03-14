using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LandScaping.Models;

namespace LandScaping.Controllers
{
    public class ProjectSheetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectSheets
        public ActionResult Index()
        {
            return View(db.projects.ToList());
        }

        // GET: ProjectSheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSheet projectSheet = db.projects.Find(id);
            if (projectSheet == null)
            {
                return HttpNotFound();
            }
            return View(projectSheet);
        }

        // GET: ProjectSheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,Month,Comments")] ProjectSheet projectSheet)
        {
            if (ModelState.IsValid)
            {
                db.projects.Add(projectSheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectSheet);
        }

        // GET: ProjectSheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSheet projectSheet = db.projects.Find(id);
            if (projectSheet == null)
            {
                return HttpNotFound();
            }
            return View(projectSheet);
        }

        // POST: ProjectSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,Month,Comments")] ProjectSheet projectSheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectSheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectSheet);
        }

        // GET: ProjectSheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectSheet projectSheet = db.projects.Find(id);
            if (projectSheet == null)
            {
                return HttpNotFound();
            }
            return View(projectSheet);
        }

        // POST: ProjectSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectSheet projectSheet = db.projects.Find(id);
            db.projects.Remove(projectSheet);
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
