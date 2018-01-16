using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sil3.Models;
using GridMvc.Html;
using GridMvc.Pagination;
using GridMvc.Sorting;

namespace Sil3.Controllers
{
    public class MalzemesController : Controller
    {
        private StokAppDbEntities db = new StokAppDbEntities();

        // GET: Malzemes
        public ActionResult Index()
        {
            var malzeme = db.Malzeme.Include(m => m.Birim).Include(m => m.Grup);
            return View(malzeme.ToList());
           
        }

        // GET: Malzemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malzeme malzeme = db.Malzeme.Find(id);
            if (malzeme == null)
            {
                return HttpNotFound();
            }
            return View(malzeme);
        }

        // GET: Malzemes/Create
        public ActionResult Create()
        {
            ViewBag.BirimId = new SelectList(db.Birim, "Id", "Ad");
            ViewBag.GrupId = new SelectList(db.Grup, "Id", "Ad");
            return View();
        }

        // POST: Malzemes/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kod,Ad,Barkod,GrupId,BirimId,KdvOrani")] Malzeme malzeme)
        {
            if (ModelState.IsValid)
            {
                db.Malzeme.Add(malzeme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirimId = new SelectList(db.Birim, "Id", "Ad", malzeme.BirimId);
            ViewBag.GrupId = new SelectList(db.Grup, "Id", "Ad", malzeme.GrupId);
            return View(malzeme);
        }

        // GET: Malzemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malzeme malzeme = db.Malzeme.Find(id);
            if (malzeme == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirimId = new SelectList(db.Birim, "Id", "Ad", malzeme.BirimId);
            ViewBag.GrupId = new SelectList(db.Grup, "Id", "Ad", malzeme.GrupId);
            return View(malzeme);
        }

        // POST: Malzemes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kod,Ad,Barkod,GrupId,BirimId,KdvOrani")] Malzeme malzeme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(malzeme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirimId = new SelectList(db.Birim, "Id", "Ad", malzeme.BirimId);
            ViewBag.GrupId = new SelectList(db.Grup, "Id", "Ad", malzeme.GrupId);
            return View(malzeme);
        }

        // GET: Malzemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Malzeme malzeme = db.Malzeme.Find(id);
            if (malzeme == null)
            {
                return HttpNotFound();
            }
            return View(malzeme);
        }

        // POST: Malzemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Malzeme malzeme = db.Malzeme.Find(id);
            db.Malzeme.Remove(malzeme);
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
