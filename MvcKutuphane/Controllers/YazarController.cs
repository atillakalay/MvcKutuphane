using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        private DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var deger = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var degerler = db.TBLYAZAR.Find(id);
            return View("YazarGetir",degerler);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yazar = db.TBLYAZAR.Find(p.ID);
            if (yazar != null)
            {
                yazar.AD = p.AD;
                yazar.SOYAD = p.SOYAD;
                yazar.DETAY = p.DETAY;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}