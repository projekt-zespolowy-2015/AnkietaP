using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnkietaP.Models;
using System.Text;


namespace AnkietaP.Controllers
{
    public class mieszkaniecsController : Controller
    {
        private AnkietaEntities3 db = new AnkietaEntities3();

        

        // GET: mieszkaniecs
        public ActionResult Index()
        {
            return View(db.mieszkaniecs.ToList());
        }

        // GET: mieszkaniecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            mieszkaniec mieszkaniec = db.mieszkaniecs.Find(id);
            if (mieszkaniec == null)
            {
                return HttpNotFound();
            }
            return View(mieszkaniec);
        }

        public ActionResult Login()
        {                       
            return View();
        } 

        public ActionResult DetailsP(string pes, string pas)
        {
            if (String.IsNullOrEmpty(pes))
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string pes2;
            pes2 = pes; //.ToString();
            mieszkaniec wynik = (from s in db.mieszkaniecs where s.pesel == pes2 select s).FirstOrDefault();
            string passwd = (wynik.password).ToString();

            if (!passwd.Equals(pas))
            {
                return Redirect("Login");
            }
                     
            //if (!String.IsNullOrEmpty(pes2))
            //{
             //   wynik = wynik.Where(s => s.pesel.Contains(pes2));
            //}
            //IEnumerable<SelectListItem> wynik = db.mieszkaniecs.Where(s => s.pesel.ToString() == pes2).Select(s => new SelectListItem { Text = s.pesel, Value = s.id_mieszkaniec.ToString() });
            //ViewBag.sSelector = wynik;
           // if (String.IsNullOrEmpty(wynik))
            //{
             //   return RedirectToAction("Index" ,"Home");
            //}
           //var mieszkaniec = wynik;
            //if (mieszkaniec == null)
            //{
            //    return HttpNotFound();
            //}
            return View(wynik);
        }

        // GET: mieszkaniecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mieszkaniecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mieszkaniec,pesel,imie,nazwisko,telefon,email")] mieszkaniec mieszkaniec)
        {
            if (ModelState.IsValid)
            {
                db.mieszkaniecs.Add(mieszkaniec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mieszkaniec);
        }

        // GET: mieszkaniecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mieszkaniec mieszkaniec = db.mieszkaniecs.Find(id);
            if (mieszkaniec == null)
            {
                return HttpNotFound();
            }
            return View(mieszkaniec);
        }

        // POST: mieszkaniecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mieszkaniec,pesel,imie,nazwisko,telefon,email,password")] mieszkaniec mieszkaniec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mieszkaniec).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("DetailsP");
                return View(mieszkaniec);
            }
            return View(mieszkaniec);
        }

        // GET: mieszkaniecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mieszkaniec mieszkaniec = db.mieszkaniecs.Find(id);
            if (mieszkaniec == null)
            {
                return HttpNotFound();
            }
            return View(mieszkaniec);
        }

        // POST: mieszkaniecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mieszkaniec mieszkaniec = db.mieszkaniecs.Find(id);
            db.mieszkaniecs.Remove(mieszkaniec);
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
