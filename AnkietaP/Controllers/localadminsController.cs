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
    public class localadminsController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: localadmins
        public ActionResult Index()
        {
            return View(db.localadmins.ToList());
        }

        // GET: localadmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            localadmin localadmin = db.localadmins.Find(id);
            if (localadmin == null)
            {
                return HttpNotFound();
            }
            return View(localadmin);
        }

        // GET: localadmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: localadmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_admin,loginin,pass,imie,nazwisko,telefon,email")] localadmin localadmin)
        {
            if (ModelState.IsValid)
            {
                db.localadmins.Add(localadmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localadmin);
        }

        // GET: localadmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            localadmin localadmin = db.localadmins.Find(id);
            if (localadmin == null)
            {
                return HttpNotFound();
            }
            return View(localadmin);
        }

        // POST: localadmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_admin,loginin,pass,imie,nazwisko,telefon,email")] localadmin localadmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localadmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localadmin);
        }

        // GET: localadmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            localadmin localadmin = db.localadmins.Find(id);
            if (localadmin == null)
            {
                return HttpNotFound();
            }
            return View(localadmin);
        }

        // POST: localadmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            localadmin localadmin = db.localadmins.Find(id);
            db.localadmins.Remove(localadmin);
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
