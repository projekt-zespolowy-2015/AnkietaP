using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnkietaP.Models;

namespace AnkietaP.Controllers
{
    public class ankietasController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: ankietas
        public ActionResult Index()
        {
            return View(db.ankietas.ToList());
        }

        // GET: lista
        public ActionResult Lista(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "mieszkaniecs");
            } 

            return View(db.ankietas.ToList());
        }

        // GET: ankietas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ankieta ankieta = db.ankietas.Find(id);
            if (ankieta == null)
            {
                return HttpNotFound();
            }
            return View(ankieta);
        }

        // GET: ankietas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ankietas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ankieta,opis,data_od,dota_do")] ankieta ankieta)
        {
            if (ModelState.IsValid)
            {
                db.ankietas.Add(ankieta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ankieta);
        }

        // GET: ankietas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ankieta ankieta = db.ankietas.Find(id);
            if (ankieta == null)
            {
                return HttpNotFound();
            }
            return View(ankieta);
        }

        // POST: ankietas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ankieta,opis,data_od,dota_do")] ankieta ankieta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ankieta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ankieta);
        }

        // GET: ankietas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ankieta ankieta = db.ankietas.Find(id);
            if (ankieta == null)
            {
                return HttpNotFound();
            }
            return View(ankieta);
        }

        // POST: ankietas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ankieta ankieta = db.ankietas.Find(id);
            db.ankietas.Remove(ankieta);
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
