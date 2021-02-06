using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        private DBKUTUPHANEEntities2 _dbkutuphaneEntities2 = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var degerler = _dbkutuphaneEntities2.TBLDUYURULAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR t)
        {
            _dbkutuphaneEntities2.TBLDUYURULAR.Add(t);
            _dbkutuphaneEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = _dbkutuphaneEntities2.TBLDUYURULAR.Find(id);
            _dbkutuphaneEntities2.TBLDUYURULAR.Remove(duyuru);
            _dbkutuphaneEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBLDUYURULAR p)
        {
            var duyuru = _dbkutuphaneEntities2.TBLDUYURULAR.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURULAR t)
        {
            var duyuru = _dbkutuphaneEntities2.TBLDUYURULAR.Find(t.ID);
            if (duyuru != null)
            {
                duyuru.KATEGORI = t.KATEGORI;
                duyuru.ICERIK = t.ICERIK;
                duyuru.TARIH = t.TARIH;
            }

            _dbkutuphaneEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}