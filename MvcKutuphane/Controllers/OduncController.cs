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
            List<SelectListItem> deger1 = (from x in dbkutuphane.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in dbkutuphane.TBLKITAP.Where(x => x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from z in dbkutuphane.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult Oduncver(TBLHAREKET p)
        {
            var d1 = dbkutuphane.TBLUYELER.Where(x => x.ID == p.TBLUYELER.ID).FirstOrDefault();
            var d2 = dbkutuphane.TBLKITAP.Where(y => y.ID == p.TBLKITAP.ID).FirstOrDefault();
            var d3 = dbkutuphane.TBLPERSONEL.Where(z => z.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYELER = d1;
            p.TBLKITAP = d2;
            p.TBLPERSONEL = d3;
            dbkutuphane.TBLHAREKET.Add(p);
            dbkutuphane.SaveChanges();
            return RedirectToAction("Index");
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