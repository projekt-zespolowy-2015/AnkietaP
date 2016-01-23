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
    public class wynik_listaController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: wynik_lista
        public ActionResult Index()
        {
            var wynik_lista = db.wynik_lista.Include(w => w.opcje);
            return View(wynik_lista.ToList());
        }

        // GET: wynik_lista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wynik_lista wynik_lista = db.wynik_lista.Find(id);
            if (wynik_lista == null)
            {
                return HttpNotFound();
            }
            return View(wynik_lista);
        }

        // GET: wynik_lista/Create
        public ActionResult Create()
        {
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa");
            return View();
        }

        // POST: wynik_lista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_wynik_lista,ilosc,id_opcje")] wynik_lista wynik_lista)
        {
            if (ModelState.IsValid)
            {
                db.wynik_lista.Add(wynik_lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            return View(wynik_lista);
        }

        // GET: wynik_lista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wynik_lista wynik_lista = db.wynik_lista.Find(id);
            if (wynik_lista == null)
            {
                return HttpNotFound();
            }
            //wynik_lista.ilosc += 1;
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            return View(wynik_lista);
        }

        // POST: wynik_lista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_wynik_lista,ilosc,id_opcje")] wynik_lista wynik_lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wynik_lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            return View(wynik_lista);
        }

        // GET: wynik_lista/Update/5
        public ActionResult Update(int? id, int? tab)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            wynik_lista wynik_lista = db.wynik_lista.Find(id);
            if (wynik_lista == null)
            {
                return HttpNotFound();
            }
            wynik_lista.ilosc += 1;
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            return View(wynik_lista);
        }

        // POST: wynik_lista/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "id_wynik_lista,ilosc,id_opcje")] wynik_lista wynik_lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wynik_lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            return View(wynik_lista);
        }


        // GET: wynik_lista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wynik_lista wynik_lista = db.wynik_lista.Find(id);
            if (wynik_lista == null)
            {
                return HttpNotFound();
            }
            return View(wynik_lista);
        }

        // POST: wynik_lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wynik_lista wynik_lista = db.wynik_lista.Find(id);
            db.wynik_lista.Remove(wynik_lista);
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
