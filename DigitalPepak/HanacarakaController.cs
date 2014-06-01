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
    public class HanacarakaController : Controller
    {
        private DigitalPepakEntities1 db = new DigitalPepakEntities1();

        // GET: /Hanacaraka/
        public ActionResult Index()
        {
            var hanacarakas = db.Hanacarakas.Include(h => h.Kategori);
            return View(hanacarakas.ToList());
        }

        // GET: /Hanacaraka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanacaraka hanacaraka = db.Hanacarakas.Find(id);
            if (hanacaraka == null)
            {
                return HttpNotFound();
            }
            return View(hanacaraka);
        }

        // GET: /Hanacaraka/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis");
            return View();
        }

        // POST: /Hanacaraka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HanacarakaId,Aksara,GambarURL,KategoriId")] Hanacaraka hanacaraka)
        {
            if (ModelState.IsValid)
            {
                db.Hanacarakas.Add(hanacaraka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", hanacaraka.KategoriId);
            return View(hanacaraka);
        }

        // GET: /Hanacaraka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanacaraka hanacaraka = db.Hanacarakas.Find(id);
            if (hanacaraka == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", hanacaraka.KategoriId);
            return View(hanacaraka);
        }

        // POST: /Hanacaraka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HanacarakaId,Aksara,GambarURL,KategoriId")] Hanacaraka hanacaraka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanacaraka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", hanacaraka.KategoriId);
            return View(hanacaraka);
        }

        // GET: /Hanacaraka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanacaraka hanacaraka = db.Hanacarakas.Find(id);
            if (hanacaraka == null)
            {
                return HttpNotFound();
            }
            return View(hanacaraka);
        }

        // POST: /Hanacaraka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hanacaraka hanacaraka = db.Hanacarakas.Find(id);
            db.Hanacarakas.Remove(hanacaraka);
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
