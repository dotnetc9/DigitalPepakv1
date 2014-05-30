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
    public class ParibasanController : Controller
    {
        private DigitalPepakEntities db = new DigitalPepakEntities();

        // GET: /Paribasan/
        public ActionResult Index()
        {
            return View(db.Paribasans.ToList());
        }

        // GET: /Paribasan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paribasan paribasan = db.Paribasans.Find(id);
            if (paribasan == null)
            {
                return HttpNotFound();
            }
            return View(paribasan);
        }

        // GET: /Paribasan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Paribasan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ParibasanId,IsiParibasan,Artine")] Paribasan paribasan)
        {
            if (ModelState.IsValid)
            {
                db.Paribasans.Add(paribasan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paribasan);
        }

        // GET: /Paribasan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paribasan paribasan = db.Paribasans.Find(id);
            if (paribasan == null)
            {
                return HttpNotFound();
            }
            return View(paribasan);
        }

        // POST: /Paribasan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ParibasanId,IsiParibasan,Artine")] Paribasan paribasan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paribasan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paribasan);
        }

        // GET: /Paribasan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paribasan paribasan = db.Paribasans.Find(id);
            if (paribasan == null)
            {
                return HttpNotFound();
            }
            return View(paribasan);
        }

        // POST: /Paribasan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paribasan paribasan = db.Paribasans.Find(id);
            db.Paribasans.Remove(paribasan);
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
