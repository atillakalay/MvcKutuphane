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
        private DBKUTUPHANEEntities2 dbkutuphane = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var degerler = dbkutuphane.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
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

        public ActionResult Odunciade(TBLHAREKET p)
        {

            var odn = dbkutuphane.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odn);
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