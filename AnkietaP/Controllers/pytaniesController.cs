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
    public class pytaniesController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        // GET: pytanies
        public ActionResult Index()
        {
            var pytanies = db.pytanies.Include(p => p.ankieta).Include(p => p.kategoria_pytania);
            return View(pytanies.ToList());
        }


        // get: koniec
        public ActionResult Koniec (int? id, int? tab)
        {
            id = 2; tab = 1;

            if (id == null || tab == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //pytanie pytanie = db.pytanies.Find(id);
            if (tab == 1) { wynik_bool wynik_bool = db.wynik_bool.Find(id); 
                               if (wynik_bool == null)
                               { return HttpNotFound(); }
                           }

            //if(tab == 2) {
                wynik_lista wynik_lista = db.wynik_lista.Find(id);
                            if (wynik_lista == null)
                            { return HttpNotFound(); }
            //           }
            //wynik_lista.ilosc += 1;
            ViewBag.id_opcje = new SelectList(db.opcjes, "id_opcje", "nazwa", wynik_lista.id_opcje);
            //ViewBag.id_ankieta = new SelectList(db.ankietas, "id_ankieta", "opis", pytanie.id_ankieta);
            //ViewBag.id_kategoria_pytania = new SelectList(db.kategoria_pytania, "id_kategoria_pytania", "nazwa", pytanie.id_kategoria_pytania);
            return View(wynik_lista);
            }

        // POST: pytanies/koniec/5
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

        // if (tab==1) {
        //var result = db.wynik_lista.Find(id);
        //var result = from s in db.wynik_lista select s;
        //var result = (from ilosc in db.wynik_lista where ilosc.id_wynik_lista == id select ilosc).ToList();
        //result = result.Where(s => s.id_wynik_lista == id);
        //var res = from ilosc in db.wynik_lista where (id_wynik_lista == id) select new { count = counter++; ilosc.Name }; 
        //var items = result.Select(( )
        //var b = result.First();
        //int a = int.Parse(b.ToString());
        //a++; 
        //var upda = (from ilosc in db.wynik_lista where ilosc.id_wynik_lista == id select ilosc.id_wynik_lista=a);
        //upda.
        //return RedirectToAction("Home/Index");
        //return RedirectToAction("Index", "Home");
//    }




        // GET: pytanies/Question/5
        public ActionResult _Question(int? id)
        {
            //id = 3;
            // var opcjes = db.opcjes.Include(o => o.pytanie);
            //opcjes = opcjes.Where(s => s.id_pytanie == (id));
            // return View(opcjes.ToList());
            return View();
        }

        // GET: pytanies/Details/5
        public ActionResult Details(int? id)
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

        // GET: pytanies/Question/5
        public ActionResult Question(int? id)
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
       
        // GET: pytanies/Question/5
        public ActionResult _QuestionList(int? id)
        {
            //id = 3;
            var opcjes = db.opcjes.Include(o => o.pytanie);
        opcjes = opcjes.Where(s => s.id_pytanie == (id));
            return View(opcjes.ToList());
        }

    // GET: pytanies/Create
    public ActionResult Create()
        {
            ViewBag.id_ankieta = new SelectList(db.ankietas, "id_ankieta", "opis");
            ViewBag.id_kategoria_pytania = new SelectList(db.kategoria_pytania, "id_kategoria_pytania", "nazwa");
            return View();
        }

        // POST: pytanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pytanie,tresc,id_ankieta,id_kategoria_pytania")] pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                db.pytanies.Add(pytanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ankieta = new SelectList(db.ankietas, "id_ankieta", "opis", pytanie.id_ankieta);
            ViewBag.id_kategoria_pytania = new SelectList(db.kategoria_pytania, "id_kategoria_pytania", "nazwa", pytanie.id_kategoria_pytania);
            return View(pytanie);
        }

        // GET: pytanies/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.id_ankieta = new SelectList(db.ankietas, "id_ankieta", "opis", pytanie.id_ankieta);
            ViewBag.id_kategoria_pytania = new SelectList(db.kategoria_pytania, "id_kategoria_pytania", "nazwa", pytanie.id_kategoria_pytania);
            return View(pytanie);
        }

        // POST: pytanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pytanie,tresc,id_ankieta,id_kategoria_pytania")] pytanie pytanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pytanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ankieta = new SelectList(db.ankietas, "id_ankieta", "opis", pytanie.id_ankieta);
            ViewBag.id_kategoria_pytania = new SelectList(db.kategoria_pytania, "id_kategoria_pytania", "nazwa", pytanie.id_kategoria_pytania);
            return View(pytanie);
        }

        // GET: pytanies/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: pytanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pytanie pytanie = db.pytanies.Find(id);
            db.pytanies.Remove(pytanie);
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
