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
    public class KawruhBasaController : Controller
    {
        private DigitalPepakEntities db = new DigitalPepakEntities();

        // GET: /KawruhBasa/
        public ActionResult Index()
        {
            return View(db.KawruhBasas.ToList());
        }

        // GET: /KawruhBasa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KawruhBasa kawruhbasa = db.KawruhBasas.Find(id);
            if (kawruhbasa == null)
            {
                return HttpNotFound();
            }
            return View(kawruhbasa);
        }

        // GET: /KawruhBasa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KawruhBasa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="KawruhBasaId,Tembung,PodhoTegese,KosokBalen")] KawruhBasa kawruhbasa)
        {
            if (ModelState.IsValid)
            {
                db.KawruhBasas.Add(kawruhbasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kawruhbasa);
        }

        // GET: /KawruhBasa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KawruhBasa kawruhbasa = db.KawruhBasas.Find(id);
            if (kawruhbasa == null)
            {
                return HttpNotFound();
            }
            return View(kawruhbasa);
        }

        // POST: /KawruhBasa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="KawruhBasaId,Tembung,PodhoTegese,KosokBalen")] KawruhBasa kawruhbasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kawruhbasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kawruhbasa);
        }

        // GET: /KawruhBasa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KawruhBasa kawruhbasa = db.KawruhBasas.Find(id);
            if (kawruhbasa == null)
            {
                return HttpNotFound();
            }
            return View(kawruhbasa);
        }

        // POST: /KawruhBasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KawruhBasa kawruhbasa = db.KawruhBasas.Find(id);
            db.KawruhBasas.Remove(kawruhbasa);
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
