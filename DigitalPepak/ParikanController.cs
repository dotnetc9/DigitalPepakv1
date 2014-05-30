using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalPepak
{
    public class ParikanController : Controller
    {
        private DigitalPepakEntities db = new DigitalPepakEntities();

        // GET: /Parikan/
        public ActionResult Index()
        {
            return View(db.Parikans.ToList());
        }

        // GET: /Parikan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parikan parikan = db.Parikans.Find(id);
            if (parikan == null)
            {
                return HttpNotFound();
            }
            return View(parikan);
        }

        // GET: /Parikan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Parikan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ParikanId,IsiParikan")] Parikan parikan)
        {
            if (ModelState.IsValid)
            {
                db.Parikans.Add(parikan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parikan);
        }

        // GET: /Parikan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parikan parikan = db.Parikans.Find(id);
            if (parikan == null)
            {
                return HttpNotFound();
            }
            return View(parikan);
        }

        // POST: /Parikan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ParikanId,IsiParikan")] Parikan parikan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parikan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parikan);
        }

        // GET: /Parikan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parikan parikan = db.Parikans.Find(id);
            if (parikan == null)
            {
                return HttpNotFound();
            }
            return View(parikan);
        }

        // POST: /Parikan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parikan parikan = db.Parikans.Find(id);
            db.Parikans.Remove(parikan);
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
