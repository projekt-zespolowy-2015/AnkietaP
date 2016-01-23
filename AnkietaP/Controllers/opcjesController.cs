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
    public class opcjesController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: opcjes
        public ActionResult Index()
        {
            var opcjes = db.opcjes.Include(o => o.pytanie);
            return View(opcjes.ToList());
        }

        public ActionResult Tabelka(int? id)
        {
            id = 1;
            //var opcjes = db.opcjes.Include(o => o.pytanie);
            //opcjes = opcjes.Where(s => s.id_pytanie == (id));
            //return View(opcjes.ToList());
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                pytanie pytanie = db.pytanies.Find(id);
                if (pytanie == null)
                {
                    return HttpNotFound();
                }
                return View(pytanie);
            }
        }

        // GET: opcjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            opcje opcje = db.opcjes.Find(id);
            if (opcje == null)
            {
                return HttpNotFound();
            }
            return View(opcje);
        }



        // GET: opcjes/Create
        public ActionResult Create()
        {
            ViewBag.id_pytanie = new SelectList(db.pytanies, "id_pytanie", "tresc");
            return View();
        }

        // POST: opcjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_opcje,nazwa,id_pytanie")] opcje opcje)
        {
            if (ModelState.IsValid)
            {
                db.opcjes.Add(opcje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pytanie = new SelectList(db.pytanies, "id_pytanie", "tresc", opcje.id_pytanie);
            return View(opcje);
        }

        // GET: opcjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            opcje opcje = db.opcjes.Find(id);
            if (opcje == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pytanie = new SelectList(db.pytanies, "id_pytanie", "tresc", opcje.id_pytanie);
            return View(opcje);
        }

        // POST: opcjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_opcje,nazwa,id_pytanie")] opcje opcje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pytanie = new SelectList(db.pytanies, "id_pytanie", "tresc", opcje.id_pytanie);
            return View(opcje);
        }

        // GET: opcjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            opcje opcje = db.opcjes.Find(id);
            if (opcje == null)
            {
                return HttpNotFound();
            }
            return View(opcje);
        }

        // POST: opcjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            opcje opcje = db.opcjes.Find(id);
            db.opcjes.Remove(opcje);
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
