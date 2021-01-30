using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        private DBKUTUPHANEEntities dbkutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = dbkutuphane.TBLHAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Oduncver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Oduncver(TBLHAREKET p)
        {
            dbkutuphane.TBLHAREKET.Add(p);
            dbkutuphane.SaveChanges();
            return RedirectToAction("Oduncver");
        }

        public ActionResult Odunciade(int id)
        {
            var iade = dbkutuphane.TBLHAREKET.Find(id);
            return View("Odunciade", iade);
        }

        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var iade = dbkutuphane.TBLHAREKET.Find(p.ID);


            if (iade != null)
            {
                iade.UYEGETIRTARIH = System.DateTime.Now;
                iade.ISLEMDURUM = true;
            }

            dbkutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}