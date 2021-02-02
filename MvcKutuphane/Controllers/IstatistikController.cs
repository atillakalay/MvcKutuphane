using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        private DBKUTUPHANEEntities2 dbkutuphaneEntities = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var deger1 = dbkutuphaneEntities.TBLUYELER.Count();
            ViewBag.dgr1 = deger1;

            var deger2 = dbkutuphaneEntities.TBLKITAP.Count();
            ViewBag.dgr2 = deger2;

            var deger3 = dbkutuphaneEntities.TBLKITAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr3 = deger3;

            var deger4 = dbkutuphaneEntities.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr4 = deger4;

            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase postedFile)
        {
            if (postedFile.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/Template/web2/resimler/"), Path.GetFileName(postedFile.FileName));
                postedFile.SaveAs(dosyayolu);
            }

            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = dbkutuphaneEntities.TBLKITAP.Count();
            ViewBag.dgr1 = deger1;

            var deger2 = dbkutuphaneEntities.TBLUYELER.Count();
            ViewBag.dgr2 = deger2;

            var deger3 = dbkutuphaneEntities.TBLCEZALAR.Sum(x=>x.PARA);
            ViewBag.dgr3 = deger3;

            var deger4 = dbkutuphaneEntities.TBLHAREKET.Count(x=>x.ISLEMDURUM==false);
            ViewBag.dgr4 = deger4;

            var deger5 = dbkutuphaneEntities.TBLKATEGORI.Count();
            ViewBag.dgr5 = deger5;

            var deger8 = dbkutuphaneEntities.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8 = deger8;

            var deger9 = dbkutuphaneEntities.EnFazlaYayınevis().First();
            ViewBag.dgr9 = deger9;


            return View();
        }
    }
}