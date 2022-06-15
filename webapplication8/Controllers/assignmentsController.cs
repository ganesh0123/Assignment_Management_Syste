using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webapplication8;

namespace webapplication8.Controllers
{
    public class assignmentsController : Controller
    {
        private ganEntities2 db = new ganEntities2();

        // GET: assignments
        public ActionResult Index()
        {
            var assignments = db.assignments.Include(a => a.tblogin);
            return View(assignments.ToList());
        }

        // GET: assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignment assignment = db.assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: assignments/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.tblogins, "Id", "username");
            return View();
        }

        // POST: assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "assignmentid,assignmentname,userid")] assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           ViewBag.userid = new SelectList(db.tblogins, "Id", "username", assignment.userid);
            return View(assignment);
        }

        // GET: assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignment assignment = db.assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.tblogins, "Id", "username", assignment.userid);
            return View(assignment);
        }

        // POST: assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "assignmentid,assignmentname,userid")] assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.tblogins, "Id", "username", assignment.userid);
            return View(assignment);
        }

        // GET: assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignment assignment = db.assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assignment assignment = db.assignments.Find(id);
            db.assignments.Remove(assignment);
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
