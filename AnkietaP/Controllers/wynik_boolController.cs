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
            
            return View();
        }

       
    }
}