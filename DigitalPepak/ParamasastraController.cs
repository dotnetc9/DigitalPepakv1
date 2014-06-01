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
    public class ParamasastraController : Controller
    {
        private DigitalPepakEntities1 db = new DigitalPepakEntities1();

        // GET: /Paramasastra/
        public ActionResult Index()
        {
            var paramasastras = db.Paramasastras.Include(p => p.Kategori);
            return View(paramasastras.ToList());
        }

        // GET: /Paramasastra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramasastra paramasastra = db.Paramasastras.Find(id);
            if (paramasastra == null)
            {
                return HttpNotFound();
            }
            return View(paramasastra);
        }

        // GET: /Paramasastra/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis");
            return View();
        }

        // POST: /Paramasastra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ParamasastraId,Ngoko,Madya,Inggil,Indonesia,KategoriId")] Paramasastra paramasastra)
        {
            if (ModelState.IsValid)
            {
                db.Paramasastras.Add(paramasastra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", paramasastra.KategoriId);
            return View(paramasastra);
        }

        // GET: /Paramasastra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramasastra paramasastra = db.Paramasastras.Find(id);
            if (paramasastra == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", paramasastra.KategoriId);
            return View(paramasastra);
        }

        // POST: /Paramasastra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ParamasastraId,Ngoko,Madya,Inggil,Indonesia,KategoriId")] Paramasastra paramasastra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramasastra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "Jenis", paramasastra.KategoriId);
            return View(paramasastra);
        }

        // GET: /Paramasastra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramasastra paramasastra = db.Paramasastras.Find(id);
            if (paramasastra == null)
            {
                return HttpNotFound();
            }
            return View(paramasastra);
        }

        // POST: /Paramasastra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paramasastra paramasastra = db.Paramasastras.Find(id);
            db.Paramasastras.Remove(paramasastra);
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
