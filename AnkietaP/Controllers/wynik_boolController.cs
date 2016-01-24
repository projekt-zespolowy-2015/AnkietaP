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
    public class wynik_boolController : Controller
    {

        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: wynik_bool
        public ActionResult Index()
        {

            var wynik_bool = db.wynik_bool.Include(w => w.pytanie);
            return View(wynik_bool.ToList());
           // return View();
        }

        // GET: wynik_lista/Update/5
        public ActionResult UpdateB(int? id, int? tab)
        {
            //id = 1; tab = 3;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            wynik_bool wynik_bool = db.wynik_bool.Find(id);
            if (wynik_bool == null)
            {
                return HttpNotFound();
            }
            if (tab == 3) { wynik_bool.nie += 1; }
            if (tab == 2) { wynik_bool.tak += 1; }
            db.SaveChanges();
            ViewBag.id_wynik_bool = new SelectList(db.pytanies , "wynik_bool","tak","nie", wynik_bool.id_wynik_bool);
            return View(wynik_bool);
        }

        // POST: wynik_lista/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateB([Bind(Include = "wynik_bool,tak,nie")] wynik_bool wynik_bool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wynik_bool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_opcje = new SelectList(db.pytanies, "wynik_bool", "tak", "nie", wynik_bool.id_wynik_bool);
            return View(wynik_bool);
        }

    }
}