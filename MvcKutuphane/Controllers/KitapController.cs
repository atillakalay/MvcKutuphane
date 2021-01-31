using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        private DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
        public ActionResult Index(string p)
        {
            var kitaplar = from x in db.TBLKITAP select x;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger = (from x in db.TBLKATEGORI.ToList()
                                          select new SelectListItem() { Text = x.AD, Value = x.ID.ToString() }).ToList();
            ViewBag.dgr = deger;
            List<SelectListItem> deger1 = (from x in db.TBLYAZAR.ToList()
                                           select new SelectListItem() { Text = x.AD + ' ' + x.SOYAD, Value = x.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;


            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var kategori = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(k => k.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = kategori;
            p.TBLYAZAR = yazar;
            db.TBLKITAP.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            List<SelectListItem> deger = (from x in db.TBLKATEGORI.ToList()
                                          select new SelectListItem() { Text = x.AD, Value = x.ID.ToString() }).ToList();
            ViewBag.dgr = deger;
            List<SelectListItem> deger1 = (from x in db.TBLYAZAR.ToList()
                                           select new SelectListItem() { Text = x.AD + ' ' + x.SOYAD, Value = x.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;

            var kitap = db.TBLKITAP.Find(id);
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            if (kitap != null)
            {
                kitap.AD = p.AD;
                kitap.BASIMYIL = p.BASIMYIL;
                kitap.SAYFA = p.SAYFA;
                kitap.YAYINEVI = p.YAYINEVI;
                var ktg = db.TBLKATEGORI.Where(x => x.ID == p.TBLKATEGORI.ID).FirstOrDefault();
                var yzr = db.TBLYAZAR.Where(x => x.ID == p.TBLYAZAR.ID).FirstOrDefault();
                kitap.KATEGORI = ktg.ID;
                kitap.YAZAR = yzr.ID;
                kitap.DURUM = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}